using System;
using System.Windows.Forms;

namespace eRestoran.Client
{
    public partial class RezervacijaStola : UserControl
    {
        public RezervacijaStola()
        {
           
            InitializeComponent();
            ctrlStolovi.DatumRezervacije = DateTime.Now;
            ctrlStolovi.ProvjeriRezervacije();

        }

        private void datumRezervacije_ValueChanged(object sender, EventArgs e)
        {
            ctrlStolovi.DatumRezervacije = datumRezervacije.Value;
            ctrlStolovi.ProvjeriRezervacije();
        }
    }
}
