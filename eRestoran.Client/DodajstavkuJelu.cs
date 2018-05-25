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
using System.Net.Http;
using eRestoran.Data.Models;
using FastFoodDemo;

namespace eRestoran.Client
{
    public partial class DodajstavkuJelu : UserControl
    {
        private WebAPIHelper getProizvodi = new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/GetProizvodi");

        public DodajstavkuJelu()
        {
            InitializeComponent();
        }

        private void DodajstavkuJelu_Load(object sender, EventArgs e)
        {
            BindProizvodi();
        }

        private void BindProizvodi()
        {
            HttpResponseMessage responseMessage = getProizvodi.GetResponse();
            if (responseMessage.IsSuccessStatusCode)
            {
                List<Proizvod> lista = responseMessage.Content.ReadAsAsync<List<Proizvod>>().Result;
                lista.Insert(0, new Proizvod() { Naziv = "Odaberite proizvod", Id = 0 });

                ProizvodJelo.DataSource = lista;
                ProizvodJelo.DisplayMember = "Naziv";
                ProizvodJelo.ValueMember = "Id";
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
