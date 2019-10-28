using eRestoran.PCL.VM;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static eRestoran.VM.PonudaVM;

namespace FirstUserControlUsage
{
    public class CardsPanel : Panel
    {
        const int CardWidth = 180;
        private Panel panel1;
        const int CardHeight = 305;

        public IEnumerable<PonudaVM.PonudaInfo> PonudaViewModel { get; set; }
        public List<CartRow> ViewModelKorpa { get; set; }

        public CardsPanel()
        {
        }
        public CardsPanel(IEnumerable<PonudaVM.PonudaInfo> viewModel)
        {
            PonudaViewModel = viewModel.ToList();
           
        }
        public CardsPanel(List<CartRow> viewModel)
        {
            ViewModelKorpa = new List<CartRow>(viewModel);
        }


        private void Cards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DataBind();
        }

        public void DataBind()
        {
            SuspendLayout();
            Controls.Clear();

            for (int i = 0; i < PonudaViewModel.Count(); i++)
            {
                var newCtl = new CardControl(PonudaViewModel.ElementAt(i));
                newCtl.DataBind();
                SetCardControlLayout(newCtl, i);
                Controls.Add(newCtl);
            }
            ResumeLayout();
        }

        public void BindPonuda()
        {
            SuspendLayout();
            Controls.Clear();

            for (int i = 0; i < PonudaViewModel.Count(); i++)
            {
                var newCtl = new PonudaItem(PonudaViewModel.ElementAt(i));
                SetCardControlLayout(newCtl, i);
                Controls.Add(newCtl);
                newCtl.DataBind();
            }
            ResumeLayout();
        }
        public void BindKorpa()
        {
            SuspendLayout();
            Controls.Clear();

            for (int i = 0; i < ViewModelKorpa.Count; i++)
            {
                var newCtl = new CartItem(ViewModelKorpa[i]);
                SetCardControlLayout(newCtl, i);
                Controls.Add(newCtl);
                newCtl.DataBind();
            }
            ResumeLayout();
        }



        void SetCardControlLayout(UserControl ctl, int atIndex)
        {
            ctl.Width = CardWidth;
            ctl.Height = CardHeight;

            //calc visible column count
            int columnCount = Width / CardWidth;

            //calc the x index and y index.
            int xPos = (atIndex % columnCount) * CardWidth;
            int yPos = (atIndex / columnCount) * CardHeight;
            //if (atIndex % 2 == 1)
            //    xPos += 15;
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
