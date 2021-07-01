using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAppWhereAll.Models;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private readonly Entry EntryLogin = new Entry();
        private readonly Entry EntryPassword = new Entry();
        public EnterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout stackLayout = new StackLayout
            {
                Padding = 15,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label
                    {
                        Text = "Enter",
                        FontSize = 36,
                        TextColor = Color.Black,
                        Padding = 10,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Label
                    {
                        Text = "Login:",
                        TextColor = Color.Black,
                        FontSize = 18,
                        HorizontalOptions = LayoutOptions.Start
                    }
                }
            };

            stackLayout.Children.Add(EntryLogin);

            stackLayout.Children.Add(new Label
            {
                Text = "Password:",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            });

            EntryPassword.IsPassword = true;
            stackLayout.Children.Add(EntryPassword);

            Color color = Color.DeepPink;

            Button ButtonEnter = new Button();
            ButtonEnter.Text = "Enter";
            ButtonEnter.FontSize = 18;
            ButtonEnter.Background = new SolidColorBrush(color);
            ButtonEnter.TextColor = Color.White;
            ButtonEnter.HorizontalOptions = LayoutOptions.Center;
            ButtonEnter.Margin = 3;
            ButtonEnter.Clicked += ButtonEnter_Clicked;

            stackLayout.Children.Add(ButtonEnter);

            Button ButtonRegister = new Button();
            ButtonRegister.Text = "Register";
            ButtonRegister.FontSize = 18;
            ButtonRegister.Background = new SolidColorBrush(color);
            ButtonRegister.TextColor = Color.White;
            ButtonRegister.HorizontalOptions = LayoutOptions.Center;
            ButtonRegister.Margin = 3;
            ButtonRegister.Clicked += ButtonRegister_Clicked; ;

            stackLayout.Children.Add(ButtonRegister);

            Content = stackLayout;
        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new RegisterPage();
        }

        private async void ButtonEnter_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (EntryLogin.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the login field!", "OK");
                    return;
                }
                if (EntryPassword.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the password field!", "OK");
                    return;
                }

                await firebaseHelper.CheckUserInDatabase(EntryLogin.Text, EntryPassword.Text, true);

                App.CurrentUser = await firebaseHelper.GetUser(EntryLogin.Text);

                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Warning", ex.Message, "OK");
            }
        }
    }
}