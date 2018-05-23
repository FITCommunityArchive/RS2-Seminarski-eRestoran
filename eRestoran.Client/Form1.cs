using FirstUserControlUsage;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Net.Http;
using System.Collections;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Client;

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
        private LinkedList<Control> controlsHistory { get; set; }
        public string activeControl { get; set; }
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public WebAPIHelper deleteProizvod = new WebAPIHelper("http://localhost:49958/", "api/Proizvodi/DeleteProizvod");


        public Form1()
        {
            controlsHistory = new LinkedList<Control>();
            InitializeComponent();
            this.AutoValidate = AutoValidate.Disable;
            //cardsPanel1.SendToBack();
            //firstCustomControl2.SendToBack();
            //SidePanel.Height = button1.Height;
            //SidePanel.Top = button1.Top;
            button1_Click(null, null);
            //dodajProizvod.Visible = false;
            //vScrollBar1.Visible = false;
            //activeControl = firstCustomControl1.Name;
        }
        public bool DeleteProizvod(string id) {
            HttpResponseMessage responseMessage = deleteProizvod.DeleteResponse(id);
            if (responseMessage.IsSuccessStatusCode)
            {
                NapraviPanelMenu();
                return true;
            }
            return false;

            }

        public void AddToControlHistory(Control control)
        {
            controlsHistory.AddLast(control);
        }
        public void GoBack()
        {
            if (controlsHistory.Count > 5)
            {
                controlsHistory.RemoveFirst();
            }
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(controlsHistory.Last.Value);
        }
        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            cardsPanel1.Controls.Clear();
            var kont = new HomeControl();
            cardsPanel1.Controls.Add(kont);
            AddToControlHistory(kont);

            //menu(menu) -> uredi
            //SwitchActiveControls(firstCustomControl1);
            //dodajProizvod.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SwitchActiveControls(cardsPanel1);

            NapraviPanelMenu();
            //dodajProizvod.Visible = true;
        }
        public void NapraviPanelMenu()
        {
            var panel = CreateDataPanel();
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(panel);
            AddToControlHistory(panel);
            panel.DataBind();
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Da li želite zatvoriti aplikaciju . Jeste li sigurni?", "Zatvori aplikaciju", MessageBoxButtons.YesNo) == DialogResult.Yes)
            { 
                this.Close();
            }
            else
            {
                return;
            }
           
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

        private CardsPanel CreateDataPanel()
        {
            List<PonudaVM.PonudaInfo> cards = new List<PonudaVM.PonudaInfo>();
            HttpClient client = new HttpClient();
            List<PonudaVM.PonudaInfo> pica;
            client.BaseAddress = new Uri("http://localhost:49958/");
            HttpResponseMessage response = client.GetAsync("api/Proizvodi/GetProizvodi").Result;
            if (response.IsSuccessStatusCode)
            {
                pica = response.Content.ReadAsAsync<List<PonudaVM.PonudaInfo>>().Result;
                foreach (var item in pica)
                {
                    cards.Add(new PonudaVM.PonudaInfo()
                    {
                        Id = item.Id,
                        Cijena = item.Cijena,
                        Naziv = "NAZIV - " + item.Naziv,
                        Kategorija = "KATEGORIJA -" + item.Kategorija,
                        Kolicina = item.Kolicina,
                        KolicinaString = item.KolicinaString + " KOM",
                        urIPicture = new Bitmap(Image.FromFile(imagesFolderPath + "tene.jpg"), new Size(120, 100))
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

            var panel = new CardsPanel();
            panel.ViewModel = VM;
            panel.Size = cardsPanel1.Size;

            panel.AutoScroll = true;
            
            return panel;
        }

        public void SwitchActiveControls(Control newActiveControl)
        {
            var currentActiveControl = Controls.Find(activeControl, false)[0];
            if (currentActiveControl != null)
                currentActiveControl.Visible = false;
            newActiveControl.Visible = true;
            activeControl = newActiveControl.Name;
        }

        #endregion

        private void dodajProizvod_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(new UnosProizvoda());
            //firstCustomControl2.activeControl = Controls.Find(activeControl, false)[0];
            //SwitchActiveControls(firstCustomControl2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(new TipProizvodaCRUD());

            //cardsPanel1.Controls.Add(new UnosJela());
        }
        public void dodajKontrolu(Control kontrola)
        {
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(kontrola);

        }
        //korpa viewmodel
    }
}
