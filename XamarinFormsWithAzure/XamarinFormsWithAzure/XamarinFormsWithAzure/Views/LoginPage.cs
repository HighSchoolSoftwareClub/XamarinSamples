using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Auth;
using Xamarin.Forms;

namespace XamarinFormsWithAzure.Views
{
    public class LoginPage : ContentPage
    {
        IMobileServiceTable<Models.Users> UserTable = App.Client.GetTable<Models.Users>();

        Entry txtUsername = new Entry()
        {
            Placeholder = "Username"
        };

        Entry txtPassword = new Entry()
        {
            IsPassword = true,
            Placeholder = "Password"
        };

        Button btnLogin,btnRegister;

        public LoginPage()
        {
            btnLogin = new Button()
            {
                Text = "Log In"
            };
            btnRegister = new Button()
            {
                Text = "Register"
            };
            btnLogin.Clicked += BtnLogin_Clicked;
            btnRegister.Clicked += BtnRegister_Clicked;
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Xamarin.Forms.Label { Text = "Username" },
                    txtUsername,
                    new Xamarin.Forms.Label { Text = "Password" },
                    txtPassword,
                    btnLogin,
                    btnRegister
                }
            };
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.RegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var users = await UserTable.Where(u => u.Username == txtUsername.Text & u.Password == txtPassword.Text).ToListAsync();
            if (users.Count == 1)
            {
                Common.AccountManager.Save(txtUsername.Text, txtPassword.Text);
                await Navigation.PushModalAsync(new MainPage());
            }
            else
                await DisplayAlert("App", "Kullanıcı adı veya şifreniz hatalıdır.", "Tamam");
        }
    }
}
