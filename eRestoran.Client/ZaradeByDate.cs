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
using eRestoran.PCL.VM;

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
                StyleDataGrid();
                var zarada = responseMessage.Content.ReadAsAsync<RacunVM>().Result;
                dnevneByDatedataGridView.DataSource = zarada.Zarade;
                dnevneByDatedataGridView.Columns[3].Visible = false;

            }
        }

        private void StyleDataGrid()
        {
           dnevneByDatedataGridView.BorderStyle = BorderStyle.None;
           dnevneByDatedataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
           dnevneByDatedataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
           dnevneByDatedataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
           dnevneByDatedataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dnevneByDatedataGridView.BackgroundColor = Color.White;
           dnevneByDatedataGridView.EnableHeadersVisualStyles = false;
           dnevneByDatedataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
           dnevneByDatedataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dnevneByDatedataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void datumChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
