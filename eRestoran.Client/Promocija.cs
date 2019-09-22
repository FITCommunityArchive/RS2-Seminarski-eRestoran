using System;
using System.Windows.Forms;
using eRestoran.Client.Shared.Helpers;
using System.Net.Http;
using eRestoran.Client.Properties;
using Newtonsoft.Json;
using eRestoran.VM;
using System.Threading.Tasks;
using eRestoran.PCL.VM;
using System.ComponentModel;

namespace eRestoran.Client
{
    public partial class Promocija : UserControl
    {
        PonudaVM.PonudaInfo item = null;
        public Promocija()
        {
            InitializeComponent();
        }
        
        private void prikaziPronadjenjiProizvod(PonudaVM.PonudaInfo item)
        {
            toggleVisibility(true);
            nazivProizvodaTextBox.Text = item.Naziv;
            staraCijenaTextBox.Text = item.Cijena.ToString();
            promocijeCijenaTextBox.Focus();
            //var sUrl = Resources.apiUrlDevelopment + item.imageUrl;
            //WebRequest req = WebRequest.Create(sUrl);

            //WebResponse res = req.GetResponse();

            //Stream imgStream = res.GetResponseStream();
            //slikaArtiklaPromocija.Image = new Bitmap(Image.FromStream(imgStream), new Size(120, 100));

        }

        private void toggleVisibility(bool isVisible)
        {
            snimiPromocijuBtn.Visible = isVisible;

            nazivProizvodaLabel.Visible = isVisible;
            nazivProizvodaTextBox.Visible = isVisible;

            staraCijenaLabel.Visible = isVisible;
            staraCijenaTextBox.Visible = isVisible;

            promotivnaLabel.Visible = isVisible;
            promocijeCijenaTextBox.Visible = isVisible;

            datumOdLabel.Visible = isVisible;
            datumOdDate.Visible = isVisible;

            datumDoLabel.Visible = isVisible;
            datumDoDate.Visible = isVisible;

            slikaArtiklaPromocija.Visible = isVisible;
        }


        private void SearchArtikal_Click(object sender, EventArgs e)
        {
            var sifra = sifraTextBox.Text;
            var apiUrl = "";
            if (!String.IsNullOrEmpty(sifra))
            {
                apiUrl = "api/ponuda/GetProizvodBySifra/" + sifra;
                WebAPIHelper getProizvod = new WebAPIHelper(Resources.apiUrlDevelopment, apiUrl);
                HttpResponseMessage responseMessage = getProizvod.GetResponse();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    item = JsonConvert.DeserializeObject<PonudaVM.PonudaInfo>(content);
                    if (item.Id.HasValue)
                    {
                        prikaziPronadjenjiProizvod(item);
                    } else
                    {
                        toggleVisibility(false);
                        this.sifraTextBox.Focus();
                        item = null;
                        MessageBox.Show("Nazalost, ne postoji proizvod sa navedenom sifrom");

                    }

                }
            }
        }

        private void sifraTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchArtikal.PerformClick();
            }
        }

        private void Promocija_Load(object sender, EventArgs e)
        {
            this.sifraTextBox.Focus();
        }

        private void promocijeCijenaTextBox_Validating(object sender, CancelEventArgs e)
        {

            if (String.IsNullOrEmpty(promocijeCijenaTextBox.Text))
            {
                e.Cancel = true;
                promocijeCijenaTextBox.Focus();
                errorProvider.SetError(promocijeCijenaTextBox, Messages.Cijena_req);
            }
            else
            {
                if (promocijeCijenaTextBox.Text.Contains(","))
                {
                    e.Cancel = true;
                    promocijeCijenaTextBox.Focus();
                    errorProvider.SetError(promocijeCijenaTextBox, Messages.Cijena_zarez);
                }
                if (promocijeCijenaTextBox.Text.Contains("-"))
                {
                    e.Cancel = true;
                    promocijeCijenaTextBox.Focus();
                    errorProvider.SetError(promocijeCijenaTextBox, Messages.NegVrijednost);
                }
                if (!System.Text.RegularExpressions.Regex.IsMatch(promocijeCijenaTextBox.Text, "\\d+(\\.\\d{1,2})?"))
                {
                    e.Cancel = true;
                    promocijeCijenaTextBox.Focus();
                    errorProvider.SetError(promocijeCijenaTextBox, Messages.Cijena_decimale);
                }

            }
        }


        private async Task<bool> postPromotion()
        {
            var promocijeService = new WebAPIHelper(Resources.apiUrlDevelopment, "api/promocija/promovisi");
            if (item.Id != 0 && double.TryParse(promocijeCijenaTextBox.Text, out double novaCijena))
            {
                var promocija = new PromocijaVM()
                {
                    DatumOd = DateTime.SpecifyKind(datumOdDate.Value, DateTimeKind.Utc),
                    DatumDo = DateTime.SpecifyKind(datumDoDate.Value, DateTimeKind.Utc),
                    PromotivnaCijena = novaCijena,
                    StaraCijena = item.Cijena
                };

                if (item.IsJelo)
                    promocija.JeloId = item.Id;
                else
                    promocija.ProizvodId = item.Id;

                var response = promocijeService.PostResponse(promocija);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Proizvod je promovisan");
                    return true;
                }
            }
            MessageBox.Show("Nazalost, nismo uspjelo promovisat proizvod."); ;

            return false;
        }

        private void SnimiPromocijuBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.postPromotion();
                toggleVisibility(false);
                this.sifraTextBox.Text = "";
                this.nazivProizvodaTextBox.Text = "";
                this.staraCijenaTextBox.Text = "";
                this.sifraTextBox.Focus();
                item = null;
                errorProvider.Clear();

            }
        }
    }
}
