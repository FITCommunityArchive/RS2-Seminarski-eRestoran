using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace eRestoran.Mobile.Droid.Fragments
{
    public class Login : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.layout1, container, false);



            Button buttonOne = (Button)view.FindViewById(Resource.Id.btnLogin);
       ;
            buttonOne.Click += LoginEvent;

            return view;

           
        }

        private void LoginEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}