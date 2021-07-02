using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private readonly Entry EntryUserName = new Entry();
        public ProfilePage()
        {
            InitializeComponent();
            EntryUserName.Text = App.CurrentUser.UserName;
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
                        Text = "Profile",
                        FontSize = 36,
                        TextColor = Color.Black,
                        Padding = 10,
                        HorizontalOptions = LayoutOptions.Center
                    },
                    new Label
                    {
                        Text = "Username:",
                        TextColor = Color.Black,
                        FontSize = 18,
                        HorizontalOptions = LayoutOptions.Start
                    }
                }
            };

            Color color = Color.DeepPink;

            Button ButtonSaveProfileInfo = new Button
            {
                Text = "Save",
                FontSize = 18,
                Background = new SolidColorBrush(color),
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand,
                Margin = 15
            };
            ButtonSaveProfileInfo.Clicked += new EventHandler(ButtonSaveProfileInfo_Clicked);

            stackLayout.Children.Add(EntryUserName);
            stackLayout.Children.Add(ButtonSaveProfileInfo);

            Content = stackLayout;
        }

        private async Task SaveItem()
        {
            try
            {
                if (EntryUserName.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the name field!", "OK");
                    return;
                }

                await firebaseHelper.UpdateUser(App.CurrentUser.Login, EntryUserName.Text, -1, -1);

                App.CurrentUser.UserName = EntryUserName.Text;

                Application.Current.MainPage = new MainPage();
            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", e.Message, "OK");
            }
        }

        private void ButtonSaveProfileInfo_Clicked(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(
                    async () =>
                    {
                        await SaveItem();
                    });
            });
        }
    }
}