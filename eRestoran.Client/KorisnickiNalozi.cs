using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using System.Net.Http;
using eRestoran.Api.VM;
using System.Collections.Generic;
using System;
using FastFoodDemo;

namespace eRestoran.Client
{
    public partial class KorisnickiNalozi : UserControl
    {
        private WebAPIHelper getKorisniciService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/GetNaloge");
        private WebAPIHelper putKorisniciService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/PutZaposlenik");
        private WebAPIHelper deleteKorisniciService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/DeleteZaposlenik");
        private WebAPIHelper deleteKlijentService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Nalog/DeleteKlijent");
        

        public KorisnickiNalozi()
        {
            InitializeComponent();
            BindNalozi();
           
        }

        private void Uredibutton_Click(object sender, System.EventArgs e)
        {
            if (kNalozidataGridView.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex];

                if (odabraniRed.Cells[0].Value != null)
                {
                    if (odabraniRed.Cells[4].Value != null)
                    {
                        var vrstaKorisnika = (odabraniRed.Cells[3].Value.ToString());
                        if (vrstaKorisnika.CompareTo("DA") == 0)
                        {
                            var urediZaposlenika = new DodajZaposlenika(odabraniRed.Cells[4].Value.ToString());
                            ((Form1)this.ParentForm).DodajKontrolu(new DodajZaposlenika(odabraniRed.Cells[4].Value.ToString()));


                        }
                        else
                        {
                            var urediKlijenta = new DodajKlijenta(odabraniRed.Cells[4].Value.ToString());
                            ((Form1)Form.ActiveForm).DodajKontrolu(urediKlijenta);
                        }
                    }
                }
               
            }
        }

        private void FillForm(TipProizvodaVM selected)
        {
            throw new NotImplementedException();
        }

        private void Izbrisibutton_Click(object sender, EventArgs e)
        {
            if(kNalozidataGridView.SelectedCells[0].RowIndex >= 0)
            {
                var odabraniRed = kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex];

                if (kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex].Cells[0].Value != null)
                {
                    var vrstaKorisnika = (odabraniRed.Cells[3].Value.ToString());
                    if (vrstaKorisnika.CompareTo("DA") == 0)
                    {
                        HttpResponseMessage responseMessage = deleteKorisniciService.DeleteResponse(kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex].Cells[4].Value.ToString());
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            BindNalozi();
                            MessageBox.Show("Uspješno izbrisan zapis");

                        }
                        else
                            MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                    }
                    else {
                        HttpResponseMessage responseMessage = deleteKlijentService.DeleteResponse(kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex].Cells[4].Value.ToString());
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            BindNalozi();
                            MessageBox.Show("Uspješno izbrisan zapis");

                        }
                        else
                            MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                    }
                }
                else
                {
                    var vrstaKorisnika = (odabraniRed.Cells[3].Value.ToString());
                    if (vrstaKorisnika.CompareTo("DA") == 0)
                    {
                        HttpResponseMessage responseMessage = deleteKorisniciService.GetResponse(kNalozidataGridView.SelectedRows[0].Cells[4].Value.ToString());
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            BindNalozi();
                            MessageBox.Show("Uspješno izbrisan zapis");

                        }
                        else
                            MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                    }
                    else {
                        HttpResponseMessage responseMessage = deleteKlijentService.DeleteResponse(kNalozidataGridView.Rows[kNalozidataGridView.SelectedCells[0].RowIndex].Cells[4].Value.ToString());
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            BindNalozi();
                            MessageBox.Show("Uspješno izbrisan zapis");

                        }
                        else
                            MessageBox.Show("Nažalost nismo pronašli ovaj zapis !");
                    }
                }
                   

                }
            
        }

        private void BindNalozi()
        {
            HttpResponseMessage responseMessage = getKorisniciService.GetResponse();
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {

                kNalozidataGridView.DataSource = responseMessage.Content.ReadAsAsync<List<NaloziVM.NalogsRow>>().Result;
                kNalozidataGridView.Columns[4].Visible = false;
            }
        }
    }
}
