using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Http;

using eRestoran.Data.Models;
using FirstUserControlUsage;
using static FastFoodDemo.UnosProizvoda;
using eRestoran.Api.VM;
using eRestoran.Client.Shared.Helpers;
using FastFoodDemo;

namespace eRestoran.Client
{
    public partial class UrediProizvod : UserControl
    {
        Proizvod p;
        private WebAPIHelper vrsteSkladista = new WebAPIHelper("http://localhost:49958/", "api/Skladiste/GetSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper getProizvod = new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/GetProizvod");
        private WebAPIHelper putProizvod = new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/PutProizvod");
        List<MenuLista> listaMenu;


        public UrediProizvod()
        {
            InitializeComponent();
            BindVrstaMenu();
            BindSkladista();
            BindVrstaProizvoda();
        }
        public UrediProizvod(PonudaVM.PonudaInfo viewModel)
        {
            InitializeComponent();
            BindVrstaMenu();
            BindSkladista();
            BindVrstaProizvoda();
            HttpResponseMessage responseMessage = getProizvod.GetResponse(viewModel.Id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                p = responseMessage.Content.ReadAsAsync<Proizvod>().Result;
                if (p != null)
                {

                    NazivtextBox.Text = p.Naziv;
                    TipProizvodacomboBox.SelectedValue = p.TipProizvodaId;
                    TipSkladistacomboBox.SelectedValue = p.SkladisteId;
                    var get = listaMenu[Int32.Parse(p.Menu)].NazivMenua;
                    MenucomboBox.SelectedValue = get;
                    CijenatextBox.Text = p.Cijena.ToString();
                    KriticnatextBox.Text = p.KriticnaKolicina.ToString();
                    KolicinatextBox.Text = p.Kolicina.ToString();
                }
               
            }
          
        }
        private void BindVrstaMenu()
        {
            listaMenu = new List<MenuLista>();
            listaMenu.Insert(0, new MenuLista() { NazivMenua = "Molim vas odaberite !" });
            listaMenu.Insert(1, new MenuLista() { NazivMenua = "Dorucak" });
            listaMenu.Insert(2, new MenuLista() { NazivMenua = "Rucak" });
            listaMenu.Insert(3, new MenuLista() { NazivMenua = "Vecera" });

            MenucomboBox.DataSource = listaMenu;
            MenucomboBox.DisplayMember = "NazivMenua";
            MenucomboBox.ValueMember = "NazivMenua";
        }

        private void BindVrstaProizvoda()
        {
            HttpResponseMessage responseMessage = vrsteProizvoda.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<TipProizvodaVM> lista = responseMessage.Content.ReadAsAsync<List<TipProizvodaVM>>().Result;
                lista.Insert(0, new TipProizvodaVM() { Naziv = "Odaberite vrstu proizvoda", Id = 0 });
                TipProizvodacomboBox.DataSource = lista;
                TipProizvodacomboBox.DisplayMember = "Naziv";
                TipProizvodacomboBox.ValueMember = "Id";
            }
        }


        private void BindSkladista()
        {
            HttpResponseMessage responseMessage = vrsteSkladista.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<SkladisteVM> lista = responseMessage.Content.ReadAsAsync<List<SkladisteVM>>().Result;
                lista.Insert(0, new SkladisteVM() { Lokacija = "Odaberite skladište", Id = 0,Kvadratura="0" });

                TipSkladistacomboBox.DataSource = lista;
                TipSkladistacomboBox.DisplayMember = "Lokacija";
                TipSkladistacomboBox.ValueMember = "Id";
            }
        }

        private void snimiProizvodbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                p.TipProizvodaId = Convert.ToInt32(TipProizvodacomboBox.SelectedValue);
                p.SkladisteId = Convert.ToInt32(TipSkladistacomboBox.SelectedValue);
                p.Cijena = Convert.ToDouble(CijenatextBox.Text);
                p.Kolicina = Convert.ToInt32(KolicinatextBox.Text);
                p.KriticnaKolicina = Convert.ToInt32(KriticnatextBox.Text);
                p.Sifra = p.Sifra;
                p.Menu = MenucomboBox.SelectedIndex.ToString();
                p.Naziv = NazivtextBox.Text;

                HttpResponseMessage responseMessage = putProizvod.PutResponse(p.Id,p);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TipProizvodacomboBox.ResetText();
                    TipProizvodacomboBox.SelectedValue = 0;

                    TipSkladistacomboBox.ResetText();
                    TipSkladistacomboBox.SelectedValue = 0;

                    MenucomboBox.ResetText();
                    MenucomboBox.DisplayMember = "Molim vas odaberite !";

                    NazivtextBox.ResetText();
                    CijenatextBox.ResetText();
                    KolicinatextBox.ResetText();
                    KriticnatextBox.ResetText();
                    ((Form1)ParentForm).NapraviPanelMenu();

                    //treba ocistiti history, jer je ostao history od proslog menua, (ako si uredio stavku naravno)


                }
                else {
                    MessageBox.Show("Error code " + responseMessage.StatusCode + " Message -" + responseMessage.ReasonPhrase);
                }
            }
        }

        private void NazivtextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivtextBox.Text))
            {
                e.Cancel = true;
                NazivtextBox.Focus();
                errorProvider.SetError(NazivtextBox, Messages.Naziv_req);
            }
        }

        private void CijenatextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(CijenatextBox.Text))
            {
                e.Cancel = true;
                CijenatextBox.Focus();
                errorProvider.SetError(CijenatextBox, Messages.Cijena_req);
            }
            else
            {
                if (CijenatextBox.Text.Contains(","))
                {
                    e.Cancel = true;
                    CijenatextBox.Focus();
                    errorProvider.SetError(CijenatextBox, Messages.Cijena_zarez);
                }
                if (CijenatextBox.Text.Contains("-"))
                {
                    e.Cancel = true;
                    CijenatextBox.Focus();
                    errorProvider.SetError(CijenatextBox, Messages.NegVrijednost);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(CijenatextBox.Text, "\\d+(\\.\\d{1,2})?"))
                {
                    e.Cancel = true;
                    CijenatextBox.Focus();
                    errorProvider.SetError(CijenatextBox, Messages.Cijena_decimale);
                }



            }
        }

        private void KolicinatextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KolicinatextBox.Text))
            {
                e.Cancel = true;
                KolicinatextBox.Focus();
                errorProvider.SetError(KolicinatextBox, Messages.Univerzalno);
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(KolicinatextBox.Text, "[0-9]"))
            {
                e.Cancel = true;
                KolicinatextBox.Focus();
                errorProvider.SetError(KolicinatextBox, Messages.Univerzalno);
            }
        }

        private void KriticnatextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KriticnatextBox.Text))
            {
                e.Cancel = true;
                KriticnatextBox.Focus();
                errorProvider.SetError(KriticnatextBox, Messages.Univerzalno);
            }
            if (KriticnatextBox.Text.Contains("-")) {
                e.Cancel = true;
                KriticnatextBox.Focus();
                errorProvider.SetError(KriticnatextBox, Messages.NegVrijednost);
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(KriticnatextBox.Text, "[0-9]"))
            {
                e.Cancel = true;
                KriticnatextBox.Focus();
                errorProvider.SetError(KriticnatextBox, Messages.Univerzalno);
            }
        }

        private void TipProizvodacomboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TipProizvodacomboBox.SelectedIndex==0)
            {
                errorProvider.SetError(TipProizvodacomboBox, "Morate odabrati vrstu proizvoda.");
                e.Cancel = true;
               
            }
            
        }

        private void TipSkladistacomboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (TipSkladistacomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(TipSkladistacomboBox, "Morate odabrati skladište proizvoda.");
                e.Cancel = true;

            }
        }

        private void MenucomboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MenucomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(MenucomboBox, "Odaberite vrstu menua.");
                e.Cancel = true;
            }
        }
    }
}
