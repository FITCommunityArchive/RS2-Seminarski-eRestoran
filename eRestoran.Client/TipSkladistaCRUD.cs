using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using eRestoran.PCL.VM;
using eRestoran.Data.Models;

namespace eRestoran.Client
{
    public partial class TipSkladistaCRUD : UserControl
    {
        private TipSkladista tipskladiste;
        private WebAPIHelper getSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/GetTipoviSkladista");
        private WebAPIHelper deleteSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/DeleteTipSkladista");
        private WebAPIHelper postSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/PostTipSkladista");
        private WebAPIHelper putSkladistaService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/PutTipSkladista");
        private WebAPIHelper skladistaGet1Service = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipSkladistas/GetTipSkladista");




        public TipSkladistaCRUD()
        {
            InitializeComponent();
            tipskladiste = new TipSkladista();
            BindVrstaSkladista();
        }

               private void snimiSklPbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) {

                tipskladiste.Naziv = nazivSkladistaPtextBox.Text;

                if (tipskladiste.Id != 0)
                {
                    HttpResponseMessage responseMessage = putSkladistaService.PutResponse(tipskladiste.Id, tipskladiste);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno izmjenjen tip skladišta");
                        BindVrstaSkladista();
                    }
                }
                else
                {
                    HttpResponseMessage responseMessage = postSkladistaService.PostResponse(tipskladiste);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno dodat tip skladišta");
                        BindVrstaSkladista();

                    }
                }


            }

        }

        private void BindVrstaSkladista()
        {
            HttpResponseMessage responseMessage = getSkladistaService.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                StyleDataGrid();
                List<TipSkladistaVM> lista = responseMessage.Content.ReadAsAsync<List<TipSkladistaVM>>().Result;
                SkladistaDataGrid.DataSource = lista;
                SkladistaDataGrid.Columns[0].Visible = false;
               


            }
            nazivSkladistaPtextBox.ResetText();
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
                        TipSkladistaVM selected = responseMessage.Content.ReadAsAsync<TipSkladistaVM>().Result;
                        tipskladiste.Id = selected.Id;
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
                        TipSkladistaVM selected = responseMessage.Content.ReadAsAsync<TipSkladistaVM>().Result;
                        tipskladiste.Id = selected.Id;
                        FillForm(selected);
                    }

                }
            }
        }

        private void FillForm(TipSkladistaVM selected)
        {
            nazivSkladistaPtextBox.Text = selected.Naziv;
        }

        private void Izbrisibutton_Click(object sender, EventArgs e)
        {
            if(SkladistaDataGrid.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = SkladistaDataGrid.SelectedCells[0].RowIndex.ToString();

                if (SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != null)
                {
                    HttpResponseMessage responseMessage = deleteSkladistaService.DeleteResponse(SkladistaDataGrid.Rows[SkladistaDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        BindVrstaSkladista();

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
                        BindVrstaSkladista();

                        MessageBox.Show("Uspješno izbrisan zapis");

                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");

                }
            }
        }

        private void nazivSkladistaPtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nazivSkladistaPtextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(nazivSkladistaPtextBox, Messages.Univerzalno);
            }
        }
    }
}
