using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstUserControlUsage
{
    public class CardsPanel : Panel
    {
        const int CardWidth = 180;
        private Panel panel1;
        const int CardHeight = 303;

        public PonudaVM ViewModel { get; set; }

        public CardsPanel()
        {
        }
        public CardsPanel(PonudaVM viewModel)
        {
            ViewModel = viewModel;
           
        }

        private void Cards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            SuspendLayout();
            Controls.Clear();

            for (int i = 0; i < ViewModel.Ponuda.Count; i++)
            {
                var newCtl = new CardControl(ViewModel.Ponuda[i]);
                newCtl.DataBind();
                SetCardControlLayout(newCtl, i);
                Controls.Add(newCtl);
            }
            ResumeLayout();
        }

        void SetCardControlLayout(CardControl ctl, int atIndex)
        {
            ctl.Width = CardWidth;
            ctl.Height = CardHeight;

            //calc visible column count
            int columnCount = Width / CardWidth;

            //calc the x index and y index.
            int xPos = (atIndex % columnCount) * CardWidth;
            int yPos = (atIndex / columnCount) * CardHeight;

            ctl.Location = new Point(xPos, yPos);
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 0;
            this.ResumeLayout(false);

        }
    }
}
