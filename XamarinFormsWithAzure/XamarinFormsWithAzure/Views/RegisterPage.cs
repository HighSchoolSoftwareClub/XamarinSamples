using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace XamarinFormsWithAzure.Views
{
    public class RegisterPage : ContentPage
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

        Button btnLogin, btnRegister;

        public RegisterPage()
        {
            btnLogin = new Button()
            {
                Text = "Log In"
            };
            btnRegister = new Button()
            {
                Text = "Register"
            };
            btnLogin.Clicked += BtnLogin_Clicked; ;
            btnRegister.Clicked += BtnRegister_Clicked; ;
            Content = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Xamarin.Forms.Label { Text = "Username" },
                    txtUsername,
                    new Xamarin.Forms.Label { Text = "Password" },
                    txtPassword,
                    btnRegister,
                    btnLogin
                }
            };
        }

        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text) & !string.IsNullOrEmpty(txtPassword.Text))
            {
                var user = new Models.Users()
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text
                };
                await UserTable.InsertAsync(user);
                if (!string.IsNullOrEmpty(user.UserId))
                    await DisplayAlert("App", "Üyelik kaydınız başarılı bir şekilde yapılmıştır.", "Tamam");
                else
                    await DisplayAlert("App", "Kayıt olurken bir hata oluştu.", "Tamam");
            }
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));
            await Navigation.PopToRootAsync();
        }
    }
}
