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
using eRestoran.Client.Properties;
using eRestoran.Api.VM;
using eRestoran.Data.Models;
using System.Linq;

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
        private CartIndexVM cart;
        public string activeControl { get; set; }
        private string imagesFolderPath = Path.GetFullPath("~/../../../Images/");
        public WebAPIHelper deleteProizvod = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Proizvodi/DeleteProizvod");
        public WebAPIHelper deleteJelo = new WebAPIHelper(Resources.apiUrlDevelopment, "api/Jelo/DeleteJelo");


        public Form1()
        {
            controlsHistory = new LinkedList<Control>();
            InitializeComponent();
            cart = new CartIndexVM();
            cart.Jela = new List<CartRow>();
            cart.Pica = new List<CartRow>();
            cart.TotalPrice = 0;
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
        public bool AddToCartPice(CartRow cartRow) {
            CartExists();
            if (cart.Pica.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                cart.Pica.Where(x => x.Id == cartRow.Id).SingleOrDefault().Kolicina += cartRow.Kolicina;
                cart.Pica.Where(x => x.Id == cartRow.Id).SingleOrDefault().TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                return true;
            }
            CartRow pice = new CartRow();
            pice.Id = cartRow.Id;
            pice.Kolicina = cartRow.Kolicina;
            pice.Naziv = cartRow.Naziv;
            pice.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
            cart.Pica.Add(pice);
            cart.TotalPrice += pice.TotalRowPrice;
            label4.Text = cart.TotalPrice.ToString() + " KM";
            return true;
            //fali dio sa stanjem,da li ima stavke na stanju , treba uraditi poziv prema API
        }
        public bool AddToCartJelo(CartRow cartRow) {

            if (cart.Jela.Where(x => x.Id == cartRow.Id).SingleOrDefault() != null)
            {
                cart.Jela.Where(x => x.Id == cartRow.Id).SingleOrDefault().Kolicina += cartRow.Kolicina;
                cart.Jela.Where(x => x.Id == cartRow.Id).SingleOrDefault().TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
                cart.TotalPrice += cartRow.Cijena * cartRow.Kolicina;
                return true;
            }
            CartRow jelo = new CartRow();
            jelo.Id = cartRow.Id;
            jelo.Kolicina = cartRow.Kolicina;
            jelo.Naziv = cartRow.Naziv;
            jelo.TotalRowPrice = cartRow.Cijena * cartRow.Kolicina;
            cart.Jela.Add(jelo);
            cart.TotalPrice += jelo.TotalRowPrice;
            return true;
        }
        public bool RemoveFromCartPice(CartRow cartRow) {
            if (CartExists() == false)
            {
                return false;
               
            }

            cart.TotalPrice = cart.TotalPrice - cartRow.Cijena* cartRow.Kolicina;
            cart.Pica.Remove(cartRow);
            label4.Text = cart.TotalPrice.ToString() + " KM";
            //fali dio sa stanjem,da li ima stavke na stanju , treba uraditi poziv prema API

            return true;
        }
        public bool RemoveFromCartJelo(CartRow cartRow)
        {
            if (CartExists() == false)
            {
                return false;

            }

            cart.TotalPrice = cart.TotalPrice - cartRow.Cijena * cartRow.Kolicina;
            cart.Jela.Remove(cartRow);
            return true;
        }

        public bool CartExists()
        {
            if (cart != null)
            {
                return true;
            }
            else
            {
                cart = new CartIndexVM();
                cart.Jela = new List<CartRow>();
                cart.Pica = new List<CartRow>();
                cart.TotalPrice = 0;
                return false;
            }

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
        private Image GetCopyImage(string path)
        {
            using (Image im = Image.FromFile(path))
            {
                Bitmap bm = new Bitmap(im);
                return bm;
            }
        }


        public bool DeleteJelo(string id)
        {
            
            HttpResponseMessage responseMessage = deleteJelo.DeleteResponse(id);
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
            HttpResponseMessage response = client.GetAsync("api/PonudaAdministrator/GetPonuda").Result;
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
                        imageUrl = item.imageUrl
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
        public void DodajKontrolu(Control kontrola)
        {
            cardsPanel1.Controls.Clear();
            cardsPanel1.Controls.Add(kontrola);

        }
        public void izbrisiKontrolu(Control kontrola)
        {
            cardsPanel1.Controls.Remove(kontrola);
        }
        //korpa viewmodel
    }
}
