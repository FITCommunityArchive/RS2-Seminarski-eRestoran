using eRestoran.Client.Mobile.Data;
using eRestoran.Client.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetail : ContentPage
	{
		public ProductDetail ()
		{
			InitializeComponent ();
            BindingContext = DataRepository.MockDriver;
        }
        public ProductDetail(Food food)
        {
            InitializeComponent();
            BindingContext = food;

        }
    }
}