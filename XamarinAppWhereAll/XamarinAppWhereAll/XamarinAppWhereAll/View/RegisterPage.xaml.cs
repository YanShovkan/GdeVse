using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private readonly Entry EntryLogin = new Entry();
        private readonly Entry EntryName = new Entry();
        private readonly Entry EntryPassword = new Entry();
        private readonly Button ButtonRegister = new Button();
        public RegisterPage()
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
                        Text = "Registration",
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
                Text = "Name:",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            }
            );

            stackLayout.Children.Add(EntryName);

            stackLayout.Children.Add(new Label
            {
                Text = "Password:",
                TextColor = Color.Black,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            }
            );

            stackLayout.Children.Add(EntryPassword);

            Color color = Color.DeepPink;

            ButtonRegister.Text = "Register";
            ButtonRegister.FontSize = 18;
            ButtonRegister.Background = new SolidColorBrush(color);
            ButtonRegister.TextColor = Color.White;
            ButtonRegister.HorizontalOptions = LayoutOptions.Center;
            ButtonRegister.Margin = 3;
            ButtonRegister.Clicked += ButtonRegister_Clicked;

            stackLayout.Children.Add(ButtonRegister);

            Content = stackLayout;
        }

        private async Task NewItem()
        {
            try
            {
                if (EntryLogin.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the login field!", "OK");
                    return;
                }
                if (EntryName.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the username field!", "OK");
                    return;
                }
                if (EntryPassword.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the password field!", "OK");
                    return;
                }

                await firebaseHelper.AddUser(EntryName.Text, EntryLogin.Text, EntryPassword.Text, 0, 0, false);

                Application.Current.MainPage = new EnterPage();
            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", e.Message, "OK");
            }
        }

        private void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(
                    async () =>
                    {
                        await NewItem();
                    });
            });
        }
    }
}