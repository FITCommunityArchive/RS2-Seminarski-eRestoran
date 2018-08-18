using eRestoran.PCL.VM;
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
