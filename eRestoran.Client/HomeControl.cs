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

namespace eRestoran.Client
{
    public partial class HomeControl : UserControl
    {
        public HomeControl()
        {
            InitializeComponent();
        }

        private void dodajJelobutton_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new UnosProizvoda());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new TipProizvodaCRUD());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new UnosJela());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new TipSkladistaCRUD());
        }

        private void DodajKorisnikaLayout(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new DodajZaposlenika());
        }

        private void LoadKorisniciList(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new KorisnickiNalozi());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new DodajKlijenta());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ((Form1)this.ParentForm).DodajKontrolu(new SkladisteCRUD());
        }
    }
}
