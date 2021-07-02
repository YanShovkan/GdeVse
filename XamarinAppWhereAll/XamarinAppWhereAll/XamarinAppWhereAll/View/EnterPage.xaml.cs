using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            Button ButtonEnter = new Button
            {
                Text = "Enter",
                FontSize = 18,
                Background = new SolidColorBrush(color),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                Margin = 15
            };
            ButtonEnter.Clicked += ButtonEnter_Clicked;

            Button ButtonRegister = new Button
            {
                Text = "Register",
                FontSize = 18,
                Background = new SolidColorBrush(color),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = 15
            };
            ButtonRegister.Clicked += ButtonRegister_Clicked;

            StackLayout stackLayoutForButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Children =
                {
                    ButtonEnter,
                    new Label
                    {
                        Text = "OR",
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.Center,
                        TextColor = Color.Black,
                        FontSize = 18,
                        Margin = 15
                    },
                    ButtonRegister,
                }
            };

            stackLayout.Children.Add(stackLayoutForButtons);

            Content = stackLayout;
        }

        private async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
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