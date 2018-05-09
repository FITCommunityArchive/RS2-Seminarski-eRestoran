using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstUserControlUsage
{
    public partial class CardControl : UserControl
    {
        public PonudaVM.PonudaInfo ViewModel { get; set; }

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

        private void CardControl_Load(object sender, EventArgs e)
        {

        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
