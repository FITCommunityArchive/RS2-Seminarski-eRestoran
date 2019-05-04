using eRestoran.Client;
using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using eRestoran.PCL.VM;
using FirstUserControlUsage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class UnosJela : UserControl
    {
        private WebAPIHelper vrsteSkladista = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/GetSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper jeloPostService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Jelo/PostJelo");
        private WebAPIHelper jeloPutService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Jelo/PutJelo");
        private WebAPIHelper getProizvod = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/GetProizvod");
        private WebAPIHelper postImage = new WebAPIHelper(Resources.apiUrlDevelopment, "api/image/upload");
        private WebAPIHelper getJelo = new WebAPIHelper(Resources.apiUrlDevelopment, "api/ponuda/getjelo");

        List<MenuLista> listaMenu;
        private int jeloId = 0;
        public PonudaVM.PonudaInfo ViewModel { get; set; }
        public Control activeControl { get; set; }

        public UnosJela()
        {
            InitializeComponent();
            BindVrstaMenu();
        }

        public UnosJela(PonudaVM.PonudaInfo viewModel) : this()
        {
            HttpResponseMessage responseMessage = getJelo.GetResponse(viewModel.Id.ToString());

            if (responseMessage.IsSuccessStatusCode)
            {
                var jelo = responseMessage.Content.ReadAsAsync<UrediJelo>().Result;
                if (jelo != null)
                {
                    jeloId = jelo.JeloId;
                    NazivJelatextBox.Text = jelo.Naziv;
                    var get = listaMenu[Int32.Parse(jelo.Menu)].NazivMenua;
                    MenuJelacomboBox.SelectedValue = get;
                    CijenaJelatextBox.Text = jelo.Cijena.ToString();
                    SifraJelatextBox.Text = jelo.Sifra;
                    slikaKontrola1.setImage(jelo.SlikaUrl);
                    BindStavkeJela(jelo.ListaStavki);
                }
            }
        }

        private void BindStavkeJela(List<ProizvodStavka> stavkeJela)
        {
            var kontroleStavki = new DodajstavkuJelu[stavkeJela.Count];
            for (int i = 0; i < stavkeJela.Count; i++)
            {
                kontroleStavki[i] = new DodajstavkuJelu(stavkeJela[i]);
            }
            stavkeLayout.Controls.AddRange(kontroleStavki);
        }

        private void BindVrstaMenu()
        {
            listaMenu = new List<MenuLista>();
            listaMenu.Insert(0, new MenuLista() { NazivMenua = "Molim vas odaberite !" });
            listaMenu.Insert(1, new MenuLista() { NazivMenua = "Dorucak" });
            listaMenu.Insert(2, new MenuLista() { NazivMenua = "Rucak" });
            listaMenu.Insert(3, new MenuLista() { NazivMenua = "Vecera" });

            MenuJelacomboBox.DataSource = listaMenu;
            MenuJelacomboBox.DisplayMember = "NazivMenua";
            MenuJelacomboBox.ValueMember = "NazivMenua";
        }

        public class MenuLista
        {
            public string NazivMenua { get; set; }
        }

        private void snimiProizvodbtn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;

            if (stavkeLayout.Controls.Count == 0)
            {
                MessageBox.Show("Morate unijeti najmanje 1 stavku!");
                return;
            }

            var jelo = new Jelo();
            jelo.Id = jeloId;
            jelo.Cijena = Convert.ToDouble(CijenaJelatextBox.Text);
            jelo.Sifra = SifraJelatextBox.Text;
            jelo.Menu = MenuJelacomboBox.SelectedIndex.ToString();
            jelo.Naziv = NazivJelatextBox.Text;
            var stavkeJela = stavkeLayout.Controls.Cast<DodajstavkuJelu>();

            // 4 stare 
            //2
            foreach (var stavka in stavkeJela)
            {
                jelo.JelaStavke.Add(stavka.GetStavka());
            }

            HttpResponseMessage responseMessage = jeloPostService.PostResponse(jelo);
            if (responseMessage.IsSuccessStatusCode)
            {
                var proizvod = responseMessage.Content.ReadAsAsync<Proizvod>().Result;
                try
                {
                    HttpResponseMessage responseMessage2 = postImage.PostFile(proizvod.Id, slikaKontrola1.GetData()).Result;
                    var slikaUrl = responseMessage2.Headers.GetValues("image-url").ElementAt(0);
                    proizvod.SlikaUrl = slikaUrl;
                    jeloPutService.PutResponse(proizvod.Id, proizvod);
                }
                catch (Exception eee)
                {
                    var xxx = eee.Message;
                }

                MenuJelacomboBox.ResetText();
                MenuJelacomboBox.SelectedIndex = 0;
                slikaKontrola1.ClearImage();
                SifraJelatextBox.ResetText();
                NazivJelatextBox.ResetText();
                CijenaJelatextBox.ResetText();
                errorProvider.Clear();

                MessageBox.Show("Uspjesno ");
            }
        }

        private void NazivtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivJelatextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(NazivJelatextBox, Messages.Naziv_req);
            }
        }



        private void CijenatextBox_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(CijenaJelatextBox.Text))
            {
                e.Cancel = true;
                CijenaJelatextBox.Focus();
                errorProvider.SetError(CijenaJelatextBox, Messages.Cijena_req);
            }
            else
            {
                if (CijenaJelatextBox.Text.Contains(","))
                {
                    e.Cancel = true;
                    CijenaJelatextBox.Focus();
                    errorProvider.SetError(CijenaJelatextBox, Messages.Cijena_zarez);
                }
                if (CijenaJelatextBox.Text.Contains("-"))
                {
                    e.Cancel = true;
                    CijenaJelatextBox.Focus();
                    errorProvider.SetError(CijenaJelatextBox, Messages.NegVrijednost);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(CijenaJelatextBox.Text, "\\d+(\\.\\d{1,2})?"))
                {
                    e.Cancel = true;
                    CijenaJelatextBox.Focus();
                    errorProvider.SetError(CijenaJelatextBox, Messages.Cijena_decimale);
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            (this.Parent).Controls.Clear();
        }

        private void SifratextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(SifraJelatextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(SifraJelatextBox, Messages.Univerzalno);
            }
        }

        private void MenucomboBox_Validating(object sender, CancelEventArgs e)
        {
            if (MenuJelacomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(MenuJelacomboBox, "Odaberite vrstu menua.");
                e.Cancel = true;
            }
        }
        //
        public void izbrisiKontroluStavke(Control kontrola)
        {
            stavkeLayout.Controls.Remove(kontrola);
        }


        private void dodajStavkuLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var controla = new DodajstavkuJelu();
            stavkeLayout.Controls.Add(controla);
        }

        private void LayoutResized(object sender, EventArgs e)
        {
            snimiProizvodbtn.Top = stavkeLayout.Bottom + 15;
        }
    }
}
