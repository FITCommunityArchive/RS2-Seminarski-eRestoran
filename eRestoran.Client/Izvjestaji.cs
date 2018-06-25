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
using eRestoran.Client.Properties;
using System.Net.Http;
using FastFoodDemo;
using eRestoran.PCL.VM;

namespace eRestoran.Client
{
    public partial class Izvjestaji : UserControl
    {
        private WebAPIHelper danasnjaZaradaGet = new WebAPIHelper(Resources.apiUrlDevelopment, "api/izvjestaji/danasnjazarada");

        public Izvjestaji()
        {
            InitializeComponent();
            HttpResponseMessage responseMessage = danasnjaZaradaGet.PostResponse(DateTime.Now.ToString("o"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var zarada = responseMessage.Content.ReadAsAsync<RacunVM>().Result;
                dnZarada.Text = zarada.DanasnjaZarada.Iznos + " KM";
            }
        }

        private void sviizvjestajiBtn_Click(object sender, EventArgs e)
        {
           
            ((Form1)this.ParentForm).DodajKontrolu(new SviIzvjestaji());
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ((Form1)this.ParentForm).DodajKontrolu(new NarudzbeByDate());
        }

        private void Zaradebutton_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new ZaradeByDate());
        }
    }
}
