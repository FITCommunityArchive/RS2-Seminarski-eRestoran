using System;
using System.Collections.Generic;

using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using System.Net.Http;

using eRestoran.Data.Models;
using FirstUserControlUsage;

namespace eRestoran.Client
{
    public partial class JeloUredi : UserControl
    {
        private WebAPIHelper getJelo = new WebAPIHelper("http://localhost:49958/", "api/Jelo/GetJelo");
        private Jelo p;
        List<MenuLista> listaMenu;
        public JeloUredi(PonudaVM.PonudaInfo viewModel)
        {
            InitializeComponent();
            BindVrstaMenu();
            HttpResponseMessage responseMessage = getJelo.GetResponse(viewModel.Id.ToString());
            if (responseMessage.IsSuccessStatusCode)
            {
                p = responseMessage.Content.ReadAsAsync<Jelo>().Result;
                if (p != null)
                {

                    NazivJelatextBox.Text = p.Naziv;
                    var get = listaMenu[Int32.Parse(p.Menu)].NazivMenua;
                    MenuJelacomboBox.SelectedValue = get;
                    CijenaJelatextBox.Text = p.Cijena.ToString();
                    SifraJelatextBox.Text = p.Sifra.ToString();
                    slikaKontrola1.setImage(p.SlikaUrl);
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

                MenuJelacomboBox.DataSource = listaMenu;
            MenuJelacomboBox.DisplayMember = "NazivMenua";
            MenuJelacomboBox.ValueMember = "NazivMenua";
            
        }

        public class MenuLista
        {
            public string NazivMenua { get; set; }

        }
    }
}
