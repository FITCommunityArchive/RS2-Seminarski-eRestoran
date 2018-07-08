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
    }
}
