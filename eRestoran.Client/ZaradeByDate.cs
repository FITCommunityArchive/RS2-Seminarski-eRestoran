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
using eRestoran.Api.VM;

namespace eRestoran.Client
{
    public partial class ZaradeByDate : UserControl
    {
        private WebAPIHelper ZaradeGet = new WebAPIHelper(Resources.apiUrlDevelopment, "api/izvjestaji/danasnjazarada");

        public ZaradeByDate()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            HttpResponseMessage responseMessage = ZaradeGet.PostResponse(datumIzvjestaj.Value.ToString("o"));
            if (responseMessage.IsSuccessStatusCode)
            {
                var zarada = responseMessage.Content.ReadAsAsync<RacunVM>().Result;
                dnevneByDatedataGridView.DataSource = zarada.Zarade;
                dnevneByDatedataGridView.Columns[3].Visible = false;

            }
        }

        private void datumChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
