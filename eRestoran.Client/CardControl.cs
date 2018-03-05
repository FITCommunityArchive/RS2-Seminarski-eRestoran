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
        public CardViewModel ViewModel { get; set; }

        public CardControl()
        {
            InitializeComponent();
        }
        public CardControl(CardViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        public void DataBind()
        {
            SuspendLayout();

            tbAge.Text = ViewModel.Age.ToString();
            tbName.Text = ViewModel.Name;
            pbPicture.Image = ViewModel.Picture;

            ResumeLayout();
        }
    }
}
