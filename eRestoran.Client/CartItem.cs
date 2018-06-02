using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastFoodDemo;
using eRestoran.Client;
using System.IO;
using eRestoran.Api.VM;

namespace FirstUserControlUsage
{
    public partial class CartItem : UserControl
    {
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public CartRow ViewModel { get; set; }
        private int kolicina;
        public int StoId { get; set; }


        public CartItem()
        {
            InitializeComponent();
          
        }

        public CartItem(CartRow viewModel,int stoId) : this()
        {
            ViewModel = viewModel;
            this.StoId = stoId;
        }
        public void ClearCartFrom0() {
            ((Form1)this.ParentForm).RefreshCart();
        }

        public void DataBind()
        {
            SuspendLayout();
            txtNaziv.Text = ViewModel.Naziv;
            txtCijena.Text = ViewModel.Cijena.ToString() + "KM ";
            //kolicina = ((Form1)this.ParentForm).CartRowExists(ViewModel.Id);
            kolicina = ViewModel.Kolicina;
            txtCijena.Text = ViewModel.Cijena+ "KM ";
            lblKolicina.Text = kolicina.ToString();

            if (ViewModel.Imageurl != null)
            {
                pictureBox1.Image = new Bitmap(Image.FromFile(ViewModel.Imageurl), new Size(120, 100));
            }
            else
            {
                pictureBox1.Image = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(120, 100));
            }
            ResumeLayout();
        }

        private void btnDodajKolicinu_Click(object sender, EventArgs e)
        {
            if (!ViewModel.Kategorija.Contains("Jela"))
            {
                if (ViewModel.StanjeKolicina < kolicina + 1)
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
                    Imageurl = ViewModel.Imageurl
                };
                if (ViewModel.Kategorija == "Jela")
                {
                    ((Form1)this.ParentForm).TrenutnoStoId = StoId;
                    ((Form1)this.ParentForm).AddToCartJelo(stavkaKorpe);
                    return true;

                }
                else
                {
                    ((Form1)this.ParentForm).TrenutnoStoId = StoId;
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

       
    }
   


}


