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
            txtCijena.Text = ViewModel.Cijena.ToString() + "KM ";
            kolicina = ((Form1)this.ParentForm).CartRowExists(ViewModel.Id);
            lblKolicina.Text = kolicina.ToString();

            if (ViewModel.imageUrl != null)
            {
                pictureBox1.Image = new Bitmap(Image.FromFile(ViewModel.imageUrl), new Size(120, 100));
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
                    StanjeKolicina=ViewModel.Kolicina,
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


