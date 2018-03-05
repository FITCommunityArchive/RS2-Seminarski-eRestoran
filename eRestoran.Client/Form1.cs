
using FirstUserControlUsage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        CardsPanel carsPanel1 = new CardsPanel();
        public Form1()
        {
            InitializeComponent();
           
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            firstCustomControl1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            firstCustomControl1.SendToBack();
            cardsPanel1.ViewModel = LoadSomeData();
            cardsPanel1.DataBind();
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
          

            //Thanks for watching Friends...
            //Please dont forget to Subscribe... :) :) :) 
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private CardsViewModel LoadSomeData()
        {
            ObservableCollection<CardViewModel> cards = new ObservableCollection<CardViewModel>();
            cards.Add(new CardViewModel()
            {
                Age = 1,
                Name = "Dan",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Chrysanthemum.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 2,
                Name = "Gill",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 3,
                Name = "Glyn",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 4,
                Name = "Lorna",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 5,
                Name = "Holly",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 1,
                Name = "Dan",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Chrysanthemum.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 2,
                Name = "Gill",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 3,
                Name = "Glyn",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 4,
                Name = "Lorna",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            cards.Add(new CardViewModel()
            {
                Age = 5,
                Name = "Holly",
                Picture = new Bitmap(Image.FromFile("C:\\Users\\ajdin\\Pictures\\Sample\\Desert.jpg"), new Size(100, 100))
            });
            CardsViewModel VM = new CardsViewModel()
            {
                Cards = cards
            };
            return VM;
        }
    }
}
