using System;
using Xamarin.Auth;
using Xamarin.Forms;
using XamarinAppWhereAll.AppConstant;
using XamarinAppWhereAll.AuthHelpers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using XamarinAppWhereAll.Models;

namespace XamarinAppWhereAll.View
{
    public partial class LoginPage : ContentPage
    {
        Account account;
        AccountStore store;
        public LoginPage()
        {
            InitializeComponent();
            store = AccountStore.Create();

        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            string clientId = null;
            string redirectUri = null;

            clientId = AppConstant.Constants.AndroidClientId;
            redirectUri = AppConstant.Constants.AndroidRedirectUrl;


            account = store.FindAccountsForService(AppConstant.Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                AppConstant.Constants.Scope,
                new Uri(AppConstant.Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(AppConstant.Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }
        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            UserModel user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(AppConstant.Constants.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<UserModel>(userJson);
                }

                if (user != null)
                {
                    App.Current.MainPage = new NavigationPage(new MainPage());
                }
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }
    }
}
