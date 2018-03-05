using API.Models;
using ggg.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ggg
{
    public partial class MainForm : Form
    {
        //public WebAPIHelper helper = new WebAPIHelper("http://localhost:51107/", "api/korisnici");
        public MainForm()
        {
            InitializeComponent();
           
        }
        //Enter code here for your version of username and userpassword
       
        

        private void button1_Click(object sender, EventArgs e)
        {
            //define local variables from the user inputs
            //HttpResponseMessage response = helper.GetResponse(nametxtbox.Text);

            //define local variables from the user inputs
            string user = nametxtbox.Text;
            string pass = pwdtxtbox.Text;
            //check if eligible to be logged in


            //if (response.IsSuccessStatusCode)
            //{
            //Korisniks k = response.Content.ReadAsAsync<Korisniks>().Result;
            //Login login = new Login(nametxtbox.Text, k.Password);
            Login login = new Login("admin", "admin");
            if (login.IsLoggedIn(user, pass))
                {
                    MessageBox.Show("You are logged in successfully");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //show default login error message
                    MessageBox.Show("Login Error!");
                }

            //}
            //else
            //{

            //    MessageBox.Show("Error code is " + response.StatusCode + "   Reason - " + response.ReasonPhrase);
            //}
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //enter your code for forget password case
            MessageBox.Show("Under development");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Enter your code for registration form of your choice
            MessageBox.Show("Under development");
        }

       
    }
}
