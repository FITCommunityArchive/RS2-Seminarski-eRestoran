

using Xamarin.Forms;

namespace mobile1.Views
{
    public class TodayPageCS : ContentPage
    {
        public TodayPageCS() { 
        
            Title = "Today";
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Today's appointments go here",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}
