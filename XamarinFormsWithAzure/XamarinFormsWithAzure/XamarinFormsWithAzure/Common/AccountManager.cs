using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;
using System.Linq;

namespace XamarinFormsWithAzure.Common
{
    public class AccountManager
    {
        public static string Username
        {
            get
            {
                var account = CreateStore().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public static string Password
        {
            get
            {
                var account = CreateStore().FindAccountsForService(App.AppName).FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        public static void Save(string username, string password)
        {
            Account account = new Account
            {
                Username = username
            };
            account.Properties.Add("Password", password);
            CreateStore().Save(account, App.AppName);
        }

        public static void Logout()
        {
            var account = CreateStore().FindAccountsForService(App.AppName).FirstOrDefault();
            if (account != null)
                CreateStore().Delete(account, App.AppName);
        }

        private static AccountStore CreateStore()
        {
            AccountStore accountStore;
#if __IOS__
                accountStore = AccountStore.Create();
#endif

#if __ANDROID__
            accountStore = AccountStore.Create(Xamarin.Forms.Forms.Context);
#endif
            return accountStore;
        }
    }
}
