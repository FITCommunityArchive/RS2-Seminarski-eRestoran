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

namespace FirstUserControlUsage
{
    public partial class CardControl : UserControl
    {
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
            
            Kategorija.Text = ViewModel.Kategorija;
            Naziv.Text = ViewModel.Naziv;
            Cijena.Text = ViewModel.Cijena.ToString();
            Kolicina.Text = ViewModel.KolicinaString;
            pictureBox1.Image = ViewModel.urIPicture;
            ResumeLayout();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            UrediProizvod p = new UrediProizvod(ViewModel);
           var x =  (this.ParentForm).Controls.Find("cardsPanel1", true).FirstOrDefault();
            x.Controls.Clear();
            x.Controls.Add(p);
            //((Form1)this.ParentForm).activeControl=p.Name;
            //((Form1)this.ParentForm).SwitchActiveControls(p);
        }
       
    }
}
