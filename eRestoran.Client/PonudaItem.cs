using eRestoran.Client.Properties;
using eRestoran.PCL.VM;
using FastFoodDemo;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstUserControlUsage
{
    public partial class PonudaItem : UserControl
    {
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public PonudaVM.PonudaInfo ViewModel { get; set; }
        private int kolicina;

        public PonudaItem()
        {
            InitializeComponent();
        }

        public PonudaItem(PonudaVM.PonudaInfo viewModel) : this()
        {
            ViewModel = viewModel;
        }

        public void DataBind()
        {
            SuspendLayout();

            txtNaziv.Text = ViewModel.Naziv;
            txtCijena.Text = string.Concat(ViewModel.Cijena.ToString(), "KM ");
            kolicina = ((Form1)this.ParentForm).CartRowExists(ViewModel.Id);
            lblKolicina.Text = kolicina.ToString();

            Task.Run(() =>
            {
                if (ViewModel.imageUrl != null)
                {
                    var sUrl = Resources.apiUrlDevelopment + ViewModel.imageUrl;
                    WebRequest req = WebRequest.Create(sUrl);

                    WebResponse res = req.GetResponse();

                    Stream imgStream = res.GetResponseStream();

                    pictureBox1.Image = new Bitmap(Image.FromStream(imgStream), new Size(120, 100));
                    imgStream.Close();
                }
                else
                {
                    pictureBox1.Image = new Bitmap(Image.FromFile(string.Concat(imagesFolderPath, "tene.jpg")), new Size(120, 100));
                }
            });

            ResumeLayout();
        }

        private void btnDodajKolicinu_Click(object sender, EventArgs e)
        {
            if (!ViewModel.Kategorija.Contains("Jela"))
            {
                if (ViewModel.Kolicina < kolicina + 1)
                {
                    MessageBox.Show("Nema na stanju", "Info");
                    return;
                }
            }
            kolicina += 1;
            lblKolicina.Text = kolicina.ToString();
            DodajUKorpu();


        }
        public bool DodajUKorpu()
        {
            if (ViewModel.Id != null)
            {
                var stavkaKorpe = new CartRow
                {
                    Naziv = ViewModel.Naziv,
                    Cijena = ViewModel.Cijena,
                    Kolicina = kolicina,
                    Id = ViewModel.Id ?? 0,
                    Kategorija = ViewModel.Kategorija,
                    StanjeKolicina = ViewModel.Kolicina,
                    Imageurl = ViewModel.imageUrl
                };
                if (ViewModel.Kategorija == "Jela")
                {

                    ((Form1)this.ParentForm).AddToCartJelo(stavkaKorpe);
                    return true;

                }
                else
                {
                    ((Form1)this.ParentForm).AddToCartPice(stavkaKorpe);
                    return true;
                }
            }
            return false;
        }

        private void btnSmanjiKolicinu_Click(object sender, EventArgs e)
        {
            if (kolicina > 0)
            {

                kolicina -= 1;

            }
            lblKolicina.Text = kolicina.ToString();
            DodajUKorpu();

        }


        private void btnDodajStavku_Click(object sender, EventArgs e)
        {

        }

        //private void lblKolicina_TextChanged(object sender, EventArgs e)

        //{
        //    if (kolicina != 0)
        //    {
        //        DodajUKorpu();
        //    }

        //    return;
        //}
    }



}


