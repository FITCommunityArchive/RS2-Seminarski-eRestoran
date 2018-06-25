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
using eRestoran.PCL.VM;
using System.Net.Http;
using eRestoran.Data.Models;

namespace eRestoran.Client
{
    public partial class TipProizvodaCRUD : UserControl
    {
        //mjerna jedinica -  Kilogram,Dekagram,Gram,Litar,Decilitar,Centilitar
        private TipProizvoda tipProizvoda;
        private WebAPIHelper tipoviEditService = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/PutTipProizvoda");
        private WebAPIHelper tipoviGetService = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipoviProizvoda"); 
        private WebAPIHelper tipoviDelService = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/DeleteTipProizvoda");
        private WebAPIHelper tipoviDodajService = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/PostTipProizvoda");
        private WebAPIHelper tipoviGet1Service = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipProizvoda");
        List<MjernaJedinicaVM> mjernajedinicalista;
        public TipProizvodaCRUD()
        {
            InitializeComponent();
            BindVrstaProizvoda();
            tipProizvoda = new TipProizvoda();
            BindMjerneJedinice();
        }
        public TipProizvodaCRUD(int selectedId)
        {
            HttpResponseMessage responseMessage = tipoviGet1Service.GetResponse(selectedId.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                TipProizvodaVM selected= responseMessage.Content.ReadAsAsync<TipProizvodaVM>().Result;
                tipProizvoda.Id = selected.Id;
                FillForm(selected);
            }
            else 
            MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
        }

        private void FillForm(TipProizvodaVM selected)
        {
            MjernaJcomboBox.SelectedValue = (int)selected.mjernaJedinica;
            NazivTipPtextBox.Text = selected.Naziv;
        }
        private void StyleDataGrid()
        {
            TipoviDataGrid.BorderStyle = BorderStyle.None;
            TipoviDataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            TipoviDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            TipoviDataGrid.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            TipoviDataGrid.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            TipoviDataGrid.BackgroundColor = Color.White;
            TipoviDataGrid.EnableHeadersVisualStyles = false;
            TipoviDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            TipoviDataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            TipoviDataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void BindMjerneJedinice()
        {

            mjernajedinicalista = new List<MjernaJedinicaVM>();
            mjernajedinicalista.Insert(0, new MjernaJedinicaVM() { Naziv = "Molim vas odaberite !", Id = 0 });
            mjernajedinicalista.Insert(1, new MjernaJedinicaVM() { Naziv = "Kilogram", Id = 1 });
            mjernajedinicalista.Insert(2, new MjernaJedinicaVM() { Naziv = "Dekagram", Id = 2 });
            mjernajedinicalista.Insert(3, new MjernaJedinicaVM() { Naziv = "Gram", Id = 3 });
            mjernajedinicalista.Insert(4, new MjernaJedinicaVM() { Naziv = "Litar", Id = 4 });
            mjernajedinicalista.Insert(5, new MjernaJedinicaVM() { Naziv = "Decilitar", Id = 5 });
            mjernajedinicalista.Insert(6, new MjernaJedinicaVM() { Naziv = "Centilitar", Id = 6 });

            MjernaJcomboBox.DataSource = mjernajedinicalista;
            MjernaJcomboBox.DisplayMember = "Naziv";
            MjernaJcomboBox.ValueMember = "Id";
        }

        private void snimiTipPbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
               

                tipProizvoda.Naziv = NazivTipPtextBox.Text;
                tipProizvoda.MjernaJedinica = (MjernaJedinica)MjernaJcomboBox.SelectedIndex;

                if (tipProizvoda.Id!=0) {
                    HttpResponseMessage responseMessage = tipoviEditService.PutResponse(tipProizvoda.Id,tipProizvoda);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno izmjenjen tip proizvoda");
                        BindVrstaProizvoda();
                    }
                }
                else
                {
                    HttpResponseMessage responseMessage = tipoviDodajService.PostResponse(tipProizvoda);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Uspjesno dodat tip proizvoda");
                        BindVrstaProizvoda();

                    }
                }
               
            }

        }
        private void BindVrstaProizvoda()
        {
            HttpResponseMessage responseMessage = tipoviGetService.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                StyleDataGrid();
                List<TipProizvodaVM> lista = responseMessage.Content.ReadAsAsync<List<TipProizvodaVM>>().Result;
                TipoviDataGrid.DataSource = lista;
                TipoviDataGrid.Columns[0].Visible = false;
                TipoviDataGrid.Columns[2].HeaderText = "Mjerna jedinica";
                TipoviDataGrid.ClearSelection();
               

            }
            NazivTipPtextBox.ResetText();
            MjernaJcomboBox.SelectedValue = 0;
        }

        private void NazivTipPtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivTipPtextBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(NazivTipPtextBox, Messages.Univerzalno);
            }
        }

        private void MjernaJcomboBox_Validating(object sender, CancelEventArgs e)
        {
            if (MjernaJcomboBox.SelectedIndex == 0)
            {
                errorProvider1.SetError(MjernaJcomboBox, "Morate odabrati mjernu jedinicu.");
                e.Cancel = true;

            }
        }

        private void Uredibutton_Click(object sender, EventArgs e)
        {
            if (TipoviDataGrid.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = TipoviDataGrid.SelectedCells[0].RowIndex.ToString();
                
                if (TipoviDataGrid.Rows[TipoviDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString()!=null)
                {
                    HttpResponseMessage responseMessage = tipoviGet1Service.GetResponse(TipoviDataGrid.Rows[TipoviDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        TipProizvodaVM selected = responseMessage.Content.ReadAsAsync<TipProizvodaVM>().Result;
                        tipProizvoda.Id = selected.Id;
                        FillForm(selected);
                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                }
                else
                {
                    HttpResponseMessage responseMessage = tipoviGet1Service.GetResponse(TipoviDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        TipProizvodaVM selected = responseMessage.Content.ReadAsAsync<TipProizvodaVM>().Result;
                        tipProizvoda.Id = selected.Id;
                        FillForm(selected);
                    }

                }
            }
        }

        private void Izbrisibutton_Click(object sender, EventArgs e)
        {
            if (TipoviDataGrid.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = TipoviDataGrid.SelectedCells[0].RowIndex.ToString();

                if (TipoviDataGrid.Rows[TipoviDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString() != null)
                {
                    HttpResponseMessage responseMessage =tipoviDelService.DeleteResponse(TipoviDataGrid.Rows[TipoviDataGrid.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        BindVrstaProizvoda();
                        MessageBox.Show("Uspješno izbrisan zapis");

                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                }
                else
                {
                    HttpResponseMessage responseMessage = tipoviDelService.GetResponse(TipoviDataGrid.SelectedRows[0].Cells[0].Value.ToString());
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        BindVrstaProizvoda();
                        MessageBox.Show("Uspješno izbrisan zapis");

                    }
                    else
                        MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");

                }
            }
        }

       
    }
}
