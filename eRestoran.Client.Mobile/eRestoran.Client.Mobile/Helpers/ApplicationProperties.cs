﻿using eRestoran.PCL.VM;
using System.Collections.Generic;
using Xamarin.Forms;

namespace eRestoran.Client.Mobile.Helpers
{
    public static class ApplicationProperties
    {
        public static string UserToken
        {
            get
            {
                return Application.Current.Properties["user_token"].ToString();
            }
            set
            {
                Application.Current.Properties["user_token"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }

        public static int userRole
        {
            get
            {
                return (int)Application.Current.Properties["user_role"];
            }
            set
            {
                Application.Current.Properties["user_role"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }

        public static string KorisnikId
        {
            get
            {
                return Application.Current.Properties["user_id"].ToString();
            }
            set
            {
                Application.Current.Properties["user_id"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }



        public static CartIndexVM cart
        {
            get
            {
                return (CartIndexVM)Application.Current.Properties["user_cart"];
            }
            set
            {
                Application.Current.Properties["user_cart"] = value;
                Application.Current.SavePropertiesAsync();
            }
        }
     
    }
}
