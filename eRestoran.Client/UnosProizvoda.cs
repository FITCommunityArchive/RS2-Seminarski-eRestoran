using eRestoran.Client;
using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using eRestoran.PCL.VM;
using FirstUserControlUsage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class UnosProizvoda : UserControl
    {
        private WebAPIHelper vrsteSkladista = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Skladiste/GetSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper(Resources.apiUrlDevelopment, "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper proizvodiService= new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/PostProizvod");
        private WebAPIHelper getProizvod= new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/GetProizvod");
        private WebAPIHelper postImage = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/uploadimage");
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        private Proizvod proizvod;
        public PonudaVM.PonudaInfo ViewModel { get; set; }
        Image File;
        Proizvod p;

        public Control activeControl { get; set; }
        public UnosProizvoda()
        {
            InitializeComponent();
            proizvod = new Proizvod();
        }

        private void UnosProizvoda_Load(object sender, EventArgs e)
        {
            BindVrstaProizvoda();
            BindSkladista();
            BindVrstaMenu();
        }

        private void BindVrstaMenu()
        {
            List<MenuLista> lista = new List<MenuLista>();
            lista.Insert(0, new MenuLista() { NazivMenua = "Molim vas odaberite !" });
            lista.Insert(1, new MenuLista() { NazivMenua ="Dorucak"});
            lista.Insert(2, new MenuLista() { NazivMenua = "Rucak" });
            lista.Insert(3, new MenuLista() { NazivMenua = "Vecera" });
           
            MenucomboBox.DataSource = lista;
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
        public class MenuLista
        {
            public string NazivMenua { get; set; }

        }

        private void snimiProizvodbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                proizvod.TipProizvodaId = Convert.ToInt32(TipProizvodacomboBox.SelectedValue);
                proizvod.SkladisteId = Convert.ToInt32(TipSkladistacomboBox.SelectedValue);
                proizvod.Cijena = Convert.ToDouble(CijenatextBox.Text);
                proizvod.Kolicina = Convert.ToInt32(KolicinatextBox.Text);
                proizvod.Sifra = SifratextBox.Text;
                proizvod.KriticnaKolicina = Convert.ToInt32(KriticnatextBox.Text);
                proizvod.Menu = MenucomboBox.SelectedIndex.ToString();
                proizvod.Naziv = NazivtextBox.Text;
                proizvod.SlikaUrl = slikaKontrola1.SaveImage();
                HttpResponseMessage responseMessage = proizvodiService.PostResponse(proizvod);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var proizvod = responseMessage.Content.ReadAsAsync<Proizvod>().Result;
                    try
                    {
                        HttpResponseMessage responseMessage2 = postImage.PostFile(proizvod.Id, slikaKontrola1.GetData()).Result;
                        var b2b = responseMessage2.Content.ReadAsStringAsync().Result;
                    }
                    catch(Exception eee)
                    {
                        var xxx = eee.Message;
                    }
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var xxx = responseMessage.Content.ReadAsStringAsync().Result;
                    }
                        TipProizvodacomboBox.ResetText();
                    TipProizvodacomboBox.SelectedValue = 0;

                    TipSkladistacomboBox.ResetText();
                    TipSkladistacomboBox.SelectedValue = 0;

                    MenucomboBox.ResetText();
                    MenucomboBox.DisplayMember= "Molim vas odaberite !";

                    SifratextBox.ResetText();
                    NazivtextBox.ResetText();
                    CijenatextBox.ResetText();
                    KolicinatextBox.ResetText();
                    KriticnatextBox.ResetText();
                    MessageBox.Show("Uspjesno dodat proizvod");
                    var panel = ((Form1)ParentForm).NapraviPanelMenu();
                    panel.DataBind();

                }
            }

        }

        private void NazivtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivtextBox.Text)) {
                e.Cancel = true;
                errorProvider.SetError(NazivtextBox, Messages.Naziv_req);
            }
        }
        private PonudaVM LoadSomeData()
        {
            List<PonudaVM.PonudaInfo> cards = new List<PonudaVM.PonudaInfo>();
            HttpClient client = new HttpClient();
            List<PonudaVM.PonudaInfo> pica;
            client.BaseAddress = new Uri("http://localhost:49958/");
            HttpResponseMessage response = client.GetAsync("api/PonudaAdministrator/GetPica").Result;
            if (response.IsSuccessStatusCode)
            {
                pica = response.Content.ReadAsAsync<List<PonudaVM.PonudaInfo>>().Result;
                foreach (var item in pica)
                {
                    cards.Add(new PonudaVM.PonudaInfo()
                    {
                        Cijena = item.Cijena,
                        Naziv = "NAZIV - " + item.Naziv,
                        Kategorija = "KATEGORIJA -" + item.Kategorija,
                        Kolicina = item.Kolicina,
                        KolicinaString = item.KolicinaString + " KOM",
                        imageUrl = item.imageUrl


                    });

                }

            }





            //  cards.Add(new CardViewModel()
            //{
            //    Age = 1,
            //    Name = "Dan",
            //Picture = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(100, 100))
            //});
            PonudaVM VM = new PonudaVM()
            {
                Ponuda = cards
            };
            return VM;
        }


        private void CijenatextBox_Validating(object sender, CancelEventArgs e)
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
            private void button8_Click(object sender, EventArgs e)
        {

            (this.Parent).Controls.Clear();
        }

        private void KolicinatextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KolicinatextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(KolicinatextBox, Messages.Univerzalno);
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(KolicinatextBox.Text, "[0-9]"))
            {
                e.Cancel = true;
                errorProvider.SetError(KolicinatextBox, Messages.Univerzalno);
            }
        }

        private void SifratextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(SifratextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(SifratextBox, Messages.Univerzalno);
            }
        }

        //private void dodajSlikubutton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog f = new OpenFileDialog();
        //    f.Filter = "JPG(*.JPG)|*.jpg";
        //    if (f.ShowDialog() == DialogResult.OK) {
        //        File = Image.FromFile(f.FileName);
        //        ProizvodpictureBox.Image = File;
                                      
        //      }
        //}

        private void TipProizvodacomboBox_Validating(object sender, CancelEventArgs e)
        {
            if (TipProizvodacomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(TipProizvodacomboBox, "Morate odabrati vrstu proizvoda.");
                e.Cancel = true;

            }
        }

        private void TipSkladistacomboBox_Validating(object sender, CancelEventArgs e)
        {
            if (TipSkladistacomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(TipSkladistacomboBox, "Morate odabrati skladište proizvoda.");
                e.Cancel = true;

            }
        }

        private void KriticnatextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(KriticnatextBox.Text))
            {
                e.Cancel = true;
                KriticnatextBox.Focus();
                errorProvider.SetError(KriticnatextBox, Messages.Univerzalno);
            }
            if (KriticnatextBox.Text.Contains("-"))
            {
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

        private void MenucomboBox_Validating(object sender, CancelEventArgs e)
        {
            if (MenucomboBox.SelectedIndex == 0)
            {
                errorProvider.SetError(MenucomboBox, "Odaberite vrstu menua.");
                e.Cancel = true;
            }
            }
    }
}
