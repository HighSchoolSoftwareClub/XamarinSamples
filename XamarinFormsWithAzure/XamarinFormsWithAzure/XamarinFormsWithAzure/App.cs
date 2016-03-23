using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace XamarinFormsWithAzure
{
    public class App : Application
    {
        public static string AppName = "LoginSample";
        public static MobileServiceClient Client = new MobileServiceClient("https://<api-name>.azurewebsites.net");

        public App()
        {
            if (Common.AccountManager.Username == null)
                MainPage = new NavigationPage(new Views.LoginPage());
            else
                MainPage = new NavigationPage(new Views.MainPage());
        }
        
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
