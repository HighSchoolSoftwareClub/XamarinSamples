using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsWithAzure.Views
{
    public class MainPage : ContentPage
    {
        Button btnLogout = new Button()
        {
            Text = "Log Out!"
        };

        public MainPage()
        {
            btnLogout.Clicked += BtnLogout_Clicked;
            Content = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    new Label() {
                        Text = String.Format("Merhaba {0}",Common.AccountManager.Username),
                        HorizontalOptions = LayoutOptions.Center
                    },
                    btnLogout
                }
            };
        }

        private async void BtnLogout_Clicked(object sender, EventArgs e)
        {
            Common.AccountManager.Logout();
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
        }
    }
}
