using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client.Properties;
using System.Net.Http;
using eRestoran.Areas.ModulAdministracija.Models;
using System.Drawing;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace eRestoran.Client
{
    public partial class SviIzvjestaji : UserControl
    {
        private WebAPIHelper sviIzvjestajiGet = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Izvjestaji/GetSveNarudzbeKorisnici");
        private string PdfFolderPath = Path.GetFullPath("~/../../../PDF/");
        private List<KorisnikInfo> izvjestaji { get; set; }
        private int rowCounter = 0;
        private string NameFile = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        public SviIzvjestaji()
        {
            InitializeComponent();
            BindIzvjestaji();
        }

        private void BindIzvjestaji()
        {
            HttpResponseMessage responseMessage = sviIzvjestajiGet.GetResponse();
            if (responseMessage.IsSuccessStatusCode)

            {
                izvjestaji = responseMessage.Content.ReadAsAsync<List<KorisnikInfo>>().Result;
                izvjestajiDataGrid.DataSource = izvjestaji;
                izvjestajiDataGrid.Columns[0].Visible = false;
              
            }
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
                izvjestaj.Rows.Add(rowCounter + 1, izvjestaji[rowCounter].Ime, izvjestaji[rowCounter].BrojNarudzbi, izvjestaji[rowCounter].Iznos);
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
