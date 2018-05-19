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

using eRestoran.Data.Models;
using eRestoran.Client.Helpers;
using FirstUserControlUsage;
using static FastFoodDemo.UnosProizvoda;
using eRestoran.Api.VM;

namespace eRestoran.Client
{
    public partial class UrediProizvod : UserControl
    {
        Proizvod p;
        private WebAPIHelper vrsteSkladista = new WebAPIHelper("http://localhost:49958/", "api/Skladiste/GetSkladista");
        private WebAPIHelper vrsteProizvoda = new WebAPIHelper("http://localhost:49958/", "api/TipProizvodas/GetTipoviProizvoda");
        private WebAPIHelper getProizvod = new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/GetProizvod");
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
                        MenucomboBox.DisplayMember = p.Menu;
                        CijenatextBox.Text = p.Cijena.ToString();
                        KriticnatextBox.Text = p.KriticnaKolicina.ToString();
                        KolicinatextBox.Text = p.Kolicina.ToString();
                    }
                }
            
        


        }
        private void BindVrstaMenu()
        {
            List<MenuLista> lista = new List<MenuLista>();
            lista.Insert(0, new MenuLista() { NazivMenua = "Molim vas odaberite !" });
            lista.Insert(1, new MenuLista() { NazivMenua = "Dorucak" });
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
                List<SkadisteVM> lista = responseMessage.Content.ReadAsAsync<List<SkadisteVM>>().Result;
                lista.Insert(0, new SkadisteVM() { Adresa = "Odaberite skladište", Id = 0 });

                TipSkladistacomboBox.DataSource = lista;
                TipSkladistacomboBox.DisplayMember = "Adresa";
                TipSkladistacomboBox.ValueMember = "Id";

            }

        }

    }
}
