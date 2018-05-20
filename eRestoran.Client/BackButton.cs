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
    public partial class BackButton : UserControl
    {
        public BackButton()
        {
            InitializeComponent();
        }

        private void BackButtonTriger(object sender, EventArgs e)
        {
            //ok
            ((Form1)ParentForm).GoBack();
        }
    }
}
