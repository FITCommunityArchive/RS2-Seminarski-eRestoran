using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eRestoran.Client.Mobile.Models
{
   public class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public string Username { get { return username; }

            set {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));

            }

        }
        public string Password { get { return password; }

            set {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }

        }
        public string username { get; set; }
        public string password { get; set; }


        public ICommand SumbitCommand { get; set; }

        public LoginVM()
        {
            SumbitCommand = new Command(OnSubmit);
        }
        public void OnSubmit() {

            if (String.IsNullOrEmpty(Username))
            {
                MessagingCenter.Send(this, "LoginAlert","Message");

            }
        }
    }
}
