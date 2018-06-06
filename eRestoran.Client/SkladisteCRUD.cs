using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using eRestoran.Data.Models;
using System.Net.Http;
using eRestoran.Api.VM;

namespace eRestoran.Client
{
    public partial class SkladisteCRUD : UserControl
    {
        private WebAPIHelper getSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/GetSkladista");
        private WebAPIHelper deleteSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/DeleteSkladiste");
        private WebAPIHelper postSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/PostSkladiste");
        private WebAPIHelper putSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/PutSkladiste");
        private WebAPIHelper skladistaGet1Service = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/GetSkladiste");
        private WebAPIHelper tipoviGetService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/GetTipoviSkladista");

        private Skladiste skladiste;
        public SkladisteCRUD()
        {
            InitializeComponent();
            BindTipId();
            BindSkladista();
            skladiste = new Skladiste();
        }

        private void BindTipId()
        {
            HttpResponseMessage responseMessage = tipoviGetService.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<TipSkladistaVM> lista = responseMessage.Content.ReadAsAsync<List<TipSkladistaVM>>().Result;
                lista.Insert(0, new TipSkladistaVM() { Naziv = "Odaberite vrstu skladišta", Id = 0 });
                tipSkladistaComboBox.DataSource = lista;
                tipSkladistaComboBox.DisplayMember = "Naziv";
                tipSkladistaComboBox.ValueMember = "Id";

            }
        }

        private void adresaSkladistaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(adresaSkladistaTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(adresaSkladistaTextBox, Messages.Univerzalno);
            }
        }

        private void kvadraturaTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(kvadraturaTextBox.Text))
            {
                e.Cancel = true;
                kvadraturaTextBox.Focus();
                errorProvider.SetError(kvadraturaTextBox, Messages.Cijena_req);
            }
            else
            {
                if (kvadraturaTextBox.Text.Contains("-"))
                {
                    e.Cancel = true;
                    kvadraturaTextBox.Focus();
                    errorProvider.SetError(kvadraturaTextBox, Messages.NegVrijednost);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(kvadraturaTextBox.Text, "\\d+(\\.\\d{1,2})?"))
                {
                    e.Cancel = true;
                    kvadraturaTextBox.Focus();
                    errorProvider.SetError(kvadraturaTextBox, Messages.Cijena_decimale);
                }

            }
        }

        private void tipSkladistaComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (tipSkladistaComboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(tipSkladistaComboBox, "Morate odabrati tip skladišta.");
                e.Cancel = true;

            }
        }

        private void snimiSklPbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                skladiste.Adresa = adresaSkladistaTextBox.Text;
                skladiste.Kvadratura = kvadraturaTextBox.Text;
                skladiste.TipId = (int)tipSkladistaComboBox.SelectedValue;

                if (skladiste.Id != 0)
                {
                    HttpResponseMessage responseMessage = putSkladistaService.PutResponse(skladiste.Id, skladiste);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno izmjenjeno skladište");
                        BindSkladista();
                    }
                }
                else
                {
                    HttpResponseMessage responseMessage = postSkladistaService.PostResponse(skladiste);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno dodato skladište");
                        BindSkladista();

                    }
                }


            }
        }

        private void BindSkladista()
        {
            HttpResponseMessage responseMessage = getSkladistaService.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                StyleDataGrid();
                List<SkladisteVM> lista = responseMessage.Content.ReadAsAsync<List<SkladisteVM>>().Result;
                SkladistaDataGrid.DataSource = lista;
                SkladistaDataGrid.Columns[0].Visible = false;
                SkladistaDataGrid.Columns[4].Visible = false;



            }
            adresaSkladistaTextBox.ResetText();
            kvadraturaTextBox.ResetText();
            tipSkladistaComboBox.SelectedValue=0;
        }
        private void StyleDataGrid()
        {
            SkladistaDataGrid.BorderStyle = BorderStyle.None;
            SkladistaDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            SkladistaDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            SkladistaDataGrid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            SkladistaDataGrid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            SkladistaDataGrid.BackgroundColor = Color.White;
            SkladistaDataGrid.EnableHeadersVisualStyles = false;
            SkladistaDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            SkladistaDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            SkladistaDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void Uredibutton_Click(object sender, EventArgs e)
        {

            if (SkladistaDataGrid.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = SkladistaDataGrid.SelectedCells[0].RowIndex.ToString();

                if (SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != null)
                {
                    HttpResponseMessage responseMessage = skladistaGet1Service.GetResponse(SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        SkladisteVM selected = responseMessage.Content.ReadAsAsync<SkladisteVM>().Result;
                        skladiste.Id = selected.Id;
                        FillForm(selected);
                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                }
                else
                {
                    HttpResponseMessage responseMessage = skladistaGet1Service.GetResponse(SkladistaDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        SkladisteVM selected = responseMessage.Content.ReadAsAsync<SkladisteVM>().Result;
                        skladiste.Id = selected.Id;
                        FillForm(selected);
                    }

                }
            }
        }

        private void FillForm(SkladisteVM selected)
        {
            adresaSkladistaTextBox.Text = selected.Lokacija;
            kvadraturaTextBox.Text = selected.Kvadratura;
            tipSkladistaComboBox.SelectedValue = selected.TipId;

        }

        private void Izbrisibutton_Click(object sender, EventArgs e)
        {
            if (SkladistaDataGrid.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = SkladistaDataGrid.SelectedCells[0].RowIndex.ToString();

                if (SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != null)
                {
                    HttpResponseMessage responseMessage = deleteSkladistaService.DeleteResponse(SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        BindSkladista();

                        MessageBox.Show("Uspješno izbrisan zapis");

                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                }
                else
                {
                    HttpResponseMessage responseMessage = deleteSkladistaService.GetResponse(SkladistaDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        BindSkladista();

                        MessageBox.Show("Uspješno izbrisan zapis");

                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");

                }
            }
        }
    }
}
