using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace eRestoran.Client.Mobile.Droid
{
    [Activity(Label = "eRestoran.Client.Mobile", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Android.Support.V7.Widget.Toolbar toolbar = this.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
                toolbar.SetTitle(Resource.String.search_menu_title);
                SetSupportActionBar(toolbar);
            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
         
        }
    }
  
    
}

