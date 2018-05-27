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
using eRestoran.Api.VM;
using eRestoran.Client.Properties;

namespace eRestoran.Client
{
    public partial class DodajstavkuJelu : UserControl
    {
        private WebAPIHelper getProizvodi = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/GetProizvodi");

        public DodajstavkuJelu()
        {
            InitializeComponent();
            BindProizvodi();
        }

        public DodajstavkuJelu(ProizvodStavka stavka) : this()
        {
            KolicinaJelotextBox.Text = stavka.Kolicina.ToString();
            ProizvodJelo.SelectedValue = stavka.ProizvodId;
            ProizvodJelo.Enabled = false;
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

        public JelaStavke GetStavka()
        {
            return new JelaStavke()
            {
                Kolicina = int.Parse(KolicinaJelotextBox.Text),
                ProizvodId = (int)ProizvodJelo.SelectedValue
            };
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);

        }
    }
}
