using Xamarin.Forms;
using XamarinAppWhereAll.Models;
using XamarinAppWhereAll.View;

namespace XamarinAppWhereAll
{
    public partial class App : Application
    {
        public static UserModel CurrentUser;
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public App()
        {
            InitializeComponent();

            MainPage = new EnterPage();
        }

        protected override void OnStart() { }

        protected override async void OnSleep()
        {
            base.OnSleep();
            if (CurrentUser != null)
            {
                await firebaseHelper.CheckUserInDatabase(CurrentUser.Login, CurrentUser.Password, false);
            }
        }

        protected override async void OnResume()
        {
            base.OnResume();
            if (CurrentUser != null)
            {
                await firebaseHelper.CheckUserInDatabase(CurrentUser.Login, CurrentUser.Password, true);
            }
        }
    }
}