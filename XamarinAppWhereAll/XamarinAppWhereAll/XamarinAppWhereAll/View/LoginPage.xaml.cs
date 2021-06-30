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

            clientId = Constants.AndroidClientId;
            redirectUri = Constants.AndroidRedirectUrl;


            account = store.FindAccountsForService(AppConstant.Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.Scope,
                new Uri(Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.AccessTokenUrl),
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
            App.Current.MainPage = new NavigationPage(new MainPage());
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
