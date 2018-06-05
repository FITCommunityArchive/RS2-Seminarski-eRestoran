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
using System.IO;
using eRestoran.Areas.ModulAdministracija.Models;
using System.Net.Http;

namespace eRestoran.Client
{
    public partial class NarudzbeByDate : UserControl
    {
        private WebAPIHelper sviIzvjestajiDatum = new WebAPIHelper(Resources.apiUrlDevelopment, "api/izvjestaji/getbydate");
        private List<NarudbaDatum.NarudzbaRow> izvjestaji { get; set; }
        private int rowCounter = 0;
        private string PdfFolderPath = Path.GetFullPath("~/../../../PDF/");
        private string NameFile = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;

        public NarudzbeByDate()
        {
            InitializeComponent();
            BindIzvjestaji();
        }
        private void BindIzvjestaji()
        {
            HttpResponseMessage responseMessage = sviIzvjestajiDatum.PostResponse(datumIzvjestaj.Value.ToString("o"));
            if (responseMessage.IsSuccessStatusCode)

            {
                izvjestaji = responseMessage.Content.ReadAsAsync<List<NarudbaDatum.NarudzbaRow>>().Result;
                dateIzvjestajidataGrid.DataSource = izvjestaji;
                dateIzvjestajidataGrid.Columns[0].Visible = false;
                dateIzvjestajidataGrid.Columns[4].Visible = false;

            }
        }

        private void datumChanged(object sender, EventArgs e)
        {
            BindIzvjestaji();
        }
        DataTable MakeDataTable()
        {

            DataTable izvjestaj = new DataTable();

            //Define columns
            izvjestaj.Columns.Add("Broj zapisa");
            izvjestaj.Columns.Add("Ime i prezime korisnika");
            izvjestaj.Columns.Add("Broj narudzbi");
            izvjestaj.Columns.Add("Iznos svih narudzbi");

            foreach (var item in izvjestaji)
            {
                izvjestaj.Rows.Add(rowCounter + 1, izvjestaji[rowCounter].KlijentIme, izvjestaji[rowCounter].Datum, izvjestaji[rowCounter].Iznos);
                ++rowCounter;

            }
            return izvjestaj;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dtbl = MakeDataTable();
                PdfHelper.ExportToPdf(dtbl);
                if (cbxOpen.Checked)
                {
                    System.Diagnostics.Process.Start(PdfFolderPath + NameFile + ".pdf");
                    this.ParentForm.WindowState = System.Windows.Forms.FormWindowState.Minimized;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}

