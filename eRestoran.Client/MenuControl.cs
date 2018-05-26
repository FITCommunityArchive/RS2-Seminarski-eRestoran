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

namespace FirstUserControlUsage
{
    public partial class CardControl : UserControl
    {
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public PonudaVM.PonudaInfo ViewModel { get; set; }

        public Control activeControl { get; set; }

        public CardControl()
        {
            InitializeComponent();
        }
        public CardControl(PonudaVM.PonudaInfo viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        public void DataBind()
        {
            SuspendLayout();
            Naziv.Text = ViewModel.Naziv;
            Cijena.Text = ViewModel.Cijena.ToString() + "KM ";
            Kolicina.Text = ViewModel.KolicinaString;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (ViewModel.Kategorija.Contains("Jela"))
            {
                var p = new UnosJela(ViewModel);

                ((Form1)this.ParentForm).DodajKontrolu(p);

            }
            else
            {
                UrediProizvod p = new UrediProizvod(ViewModel);
                var x = (this.ParentForm).Controls.Find("cardsPanel1", true).FirstOrDefault();
                x.Controls.Clear();
                x.Controls.Add(p);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string putanja = ViewModel.imageUrl;
            if (MessageBox.Show("Da li želite izbrisati proizvod . Jeste li sigurni?", "Brisanje proizvoda", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (!ViewModel.Kategorija.Contains("Jela"))
                {

                    if (!((Form1)this.ParentForm).DeleteProizvod(ViewModel.Id.ToString()))
                    {

                        MessageBox.Show("Nismo uspjeli izbrisati proizvod");
                    }
                    //file delete

                }
                else
                {
                    if (!((Form1)this.ParentForm).DeleteJelo(ViewModel.Id.ToString()))
                    {

                        MessageBox.Show("Nismo uspjeli izbrisati jelo");
                    }
                    //fileDelete
                }
            }
            else
            {

                return;
            }
        }



        //((Form1)this.ParentForm).activeControl=p.Name;
        //((Form1)this.ParentForm).SwitchActiveControls(p);
    }


}


