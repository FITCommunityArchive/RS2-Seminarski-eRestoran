using FirstUserControlUsage;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using eRestoran.Data.DAL;
using System.Linq;
using System.Net.Http;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private string activeControl { get; set; }
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");

        public Form1()
        {
            InitializeComponent();
            cardsPanel1.SendToBack();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
            dodajProizvod.Visible = false;
            vScrollBar1.Visible = false;
            activeControl = firstCustomControl1.Name;
        }

        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            SwitchActiveControls(firstCustomControl1);
            dodajProizvod.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchActiveControls(cardsPanel1);
            cardsPanel1.ViewModel = LoadSomeData();
            cardsPanel1.DataBind();
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            dodajProizvod.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Methods
        
        private PonudaVM LoadSomeData()
        {
            List<PonudaVM.PonudaInfo> cards = new List<PonudaVM.PonudaInfo>();
            HttpClient client = new HttpClient();
            List<PonudaVM.PonudaInfo> pica;
            client.BaseAddress = new Uri("http://localhost:49958/");
            HttpResponseMessage response = client.GetAsync("api/PonudaAdministrator/GetPica").Result;
            if (response.IsSuccessStatusCode)
            {
                 pica = response.Content.ReadAsAsync<List<PonudaVM.PonudaInfo>>().Result;
                foreach (var item in pica)
                {
                    cards.Add(new PonudaVM.PonudaInfo()
                    {
                        Cijena = item.Cijena,
                        Naziv = "NAZIV - "+item.Naziv,
                        Kategorija = "KATEGORIJA -"+item.Kategorija,
                        Kolicina = item.Kolicina,
                        KolicinaString = item.KolicinaString+" KOM",
                        urIPicture = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(100, 100))


                    });

                }

            }


            
          

            //  cards.Add(new CardViewModel()
            //{
            //    Age = 1,
            //    Name = "Dan",
            //Picture = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(100, 100))
            //});
            PonudaVM VM = new PonudaVM()
            {
                Ponuda = cards
            };
            return VM;
        }

        private void SwitchActiveControls(Control newActiveControl)
        {
            var currentActiveControl = Controls.Find(activeControl, false)[0];
            if (currentActiveControl != null)
                currentActiveControl.Visible = false;
            newActiveControl.Visible = true;
            activeControl = newActiveControl.Name;
        }
        #endregion

       
    }
}
