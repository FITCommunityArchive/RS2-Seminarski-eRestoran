
using eRestoran.Client.Properties;
using eRestoran.Client.Shared.Helpers;
using eRestoran.Data.Models;
using FastFoodDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;

using System.Windows.Forms;

namespace ggg
{
    public partial class MainForm : Form
    {
        public WebAPIHelper getUser = new WebAPIHelper(Resources.apiUrlDevelopment, "api/korisnici/korisnik");

        public MainForm()
        {
            InitializeComponent();

        }
        //Enter code here for your version of username and userpassword



        private void button1_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs

            //define local variables from the user inputs
            string user = nametxtbox.Text;
            string pass = pwdtxtbox.Text;
            //check if eligible to be logged in
            HttpResponseMessage responseMessage = getUser.GetResponse(user);


            if (responseMessage.IsSuccessStatusCode)
            {
                Korisnik k = responseMessage.Content.ReadAsAsync<Korisnik>().Result;
                if (k.Password.Equals(pass))
                {
                    Login login = new Login(user, pass);
                    if (login.IsLoggedIn(user, pass))
                    {
                        MessageBox.Show("You are logged in successfully");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        Form1 glavnaForma = new Form1();
                    }
                    else
                    {
                        //show default login error message
                        MessageBox.Show("Login Error!");
                    }
                }
                else
                {
                    MessageBox.Show("Nepostojeci username !");

                }
            }



            //}
            else
            {

                MessageBox.Show("Neispravni podaci za login !");
            }
        }




    }
}
