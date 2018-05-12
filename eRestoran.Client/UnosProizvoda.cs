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
using eRestoran.Client.Helpers;
using eRestoran.Data.Models;
using eRestoran.Client;

namespace FastFoodDemo
{
    public partial class UnosProizvoda : UserControl
    {
        private WebAPIHelper vrsteSkladista = new WebAPIHelper("http://localhost:49958/", "api/TipSkladistas/GetTipoviSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper proizvodiService= new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/PostProizvod");

        private Proizvod proizvod;

        public Control activeControl { get; set; }

        public UnosProizvoda()
        {
            InitializeComponent();
            proizvod = new Proizvod();
        }

     

      

        private void UnosProizvoda_Load(object sender, EventArgs e)
        {
            BindVrsteProizvoda();
            BindVrstaSkladista();
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

        private void BindVrstaSkladista()
        {
            HttpResponseMessage responseMessage = vrsteProizvoda.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<TipProizvoda> lista = responseMessage.Content.ReadAsAsync<List<TipProizvoda>>().Result;
                lista.Insert(0, new TipProizvoda() { Naziv = "Odaberite vrstu proizvoda", Id = 0 });
                TipProizvodacomboBox.DataSource = lista;
                TipProizvodacomboBox.DisplayMember = "Naziv";
                TipProizvodacomboBox.ValueMember = "Id";

            }
        }
 

        private void BindVrsteProizvoda()
        {
            HttpResponseMessage responseMessage = vrsteSkladista.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<TipSkladista> lista = responseMessage.Content.ReadAsAsync<List<TipSkladista>>().Result;
                lista.Insert(0, new TipSkladista() { Naziv = "Odaberite vrstu skladišta", Id = 0 });
               
                TipSkladistacomboBox.DataSource = lista;
                TipSkladistacomboBox.DisplayMember = "Naziv";
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
                proizvod.Menu = MenucomboBox.Text;
                proizvod.Naziv = NazivtextBox.Text;

                HttpResponseMessage responseMessage = proizvodiService.PostResponse(proizvod);
                if (responseMessage.IsSuccessStatusCode)
                {
                    TipProizvodacomboBox.ResetText();
                    TipProizvodacomboBox.SelectedValue = 0;

                    TipSkladistacomboBox.ResetText();
                    TipSkladistacomboBox.SelectedValue = 0;

                    MenucomboBox.ResetText();
                    MenucomboBox.SelectedValue = 1;

                    SifratextBox.ResetText();
                    NazivtextBox.ResetText();
                    CijenatextBox.ResetText();
                    KolicinatextBox.ResetText();
                    KriticnatextBox.ResetText();

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

      

        private void CijenatextBox_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(CijenatextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(CijenatextBox, Messages.Cijena_req);
            }
            else {
                if (CijenatextBox.Text.Contains(",")) {
                    e.Cancel = true;
                    errorProvider.SetError(CijenatextBox, Messages.Cijena_zarez);
                }
               

            }
        }
        

        private void CijenatextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(CijenatextBox.Text, "\\d+(\\.\\d{1,2})?"))
            {
                MessageBox.Show("Molim vas unesite ispravan format! (zaokružite na 2 decimale)");
                var err=errorProvider.GetError(CijenatextBox);
                
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ((Form1)this.Parent).SwitchActiveControls(activeControl);
        }
    }
}
