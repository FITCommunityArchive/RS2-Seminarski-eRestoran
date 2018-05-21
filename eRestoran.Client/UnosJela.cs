using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using eRestoran.Data.Models;
using eRestoran.Client;
using FirstUserControlUsage;
using System.IO;
using eRestoran.Api.VM;
using System.Drawing.Drawing2D;
using eRestoran.Client.Shared.Helpers;

namespace FastFoodDemo
{
    public partial class UnosJela : UserControl
    {
        private WebAPIHelper vrsteSkladista = new WebAPIHelper("http://localhost:49958/", "api/Skladiste/GetSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper proizvodiService= new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/PostProizvod");
        private WebAPIHelper getProizvod= new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/GetProizvod");
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        private Proizvod proizvod;
        public PonudaVM.PonudaInfo ViewModel { get; set; }
        Image File;
        Proizvod p;

        public Control activeControl { get; set; }
        public UnosJela()
        {
            InitializeComponent();
            proizvod = new Proizvod();
        }

        private void UnosProizvoda_Load(object sender, EventArgs e)
        {
                    BindVrstaMenu();
        }

        private void BindVrstaMenu()
        {
            List<MenuLista> lista = new List<MenuLista>();
            lista.Insert(0, new MenuLista() { NazivMenua = "Molim vas odaberite !" });
            lista.Insert(1, new MenuLista() { NazivMenua ="Dorucak"});
            lista.Insert(2, new MenuLista() { NazivMenua = "Rucak" });
            lista.Insert(3, new MenuLista() { NazivMenua = "Vecera" });
           
            MenuJelacomboBox.DataSource = lista;
            MenuJelacomboBox.DisplayMember = "NazivMenua";
            MenuJelacomboBox.ValueMember = "NazivMenua";


        }

        


       
        public class MenuLista
        {
            public string NazivMenua { get; set; }

        }

        private void snimiProizvodbtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
               
                proizvod.Cijena = Convert.ToDouble(CijenaJelatextBox.Text);
               
                proizvod.Sifra = SifraJelatextBox.Text;
               
                proizvod.Menu = MenuJelacomboBox.SelectedIndex.ToString();
                proizvod.Naziv = NazivJelatextBox.Text;

                HttpResponseMessage responseMessage = proizvodiService.PostResponse(proizvod);
                if (responseMessage.IsSuccessStatusCode)
                {
                   

                    MenuJelacomboBox.ResetText();
                    MenuJelacomboBox.DisplayMember= "Molim vas odaberite !";

                    SifraJelatextBox.ResetText();
                    NazivJelatextBox.ResetText();
                    CijenaJelatextBox.ResetText();
                  
                    MessageBox.Show("Uspjesno dodat proizvod");
                    ((Form1)this.ParentForm).NapraviPanelMenu();

                }
            }

        }

        private void NazivtextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(NazivJelatextBox.Text)) {
                e.Cancel = true;
                errorProvider.SetError(NazivJelatextBox, Messages.Naziv_req);
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
                        urIPicture = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(100, 100))


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

        private void dodajSlikubutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "JPG(*.JPG)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK) {
                File = Image.FromFile(f.FileName);
                ProizvodpictureBox.Image = File;
                                      
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

        private void dodajStavkuLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            var controla = new DodajstavkuJelu();
            controla.Location=new System.Drawing.Point(this.Width-720, this.Height -210);
            this.Controls.Add(controla);
            this.snimiProizvodbtn.Location = new System.Drawing.Point(this.Width - 500, this.Height - 10);
           
           
        }
    }
}
