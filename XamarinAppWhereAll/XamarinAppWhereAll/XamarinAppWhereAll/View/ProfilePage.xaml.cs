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
        Entry EntryUserName = new Entry();
        Button ButtonSaveProfileInfo = new Button();
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

            ButtonSaveProfileInfo.Text = "Save";
            ButtonSaveProfileInfo.FontSize = 18;

            Color color = Color.DeepPink;
            ButtonSaveProfileInfo.Background = new SolidColorBrush(color);

            ButtonSaveProfileInfo.TextColor = Color.White;
            ButtonSaveProfileInfo.HorizontalOptions = LayoutOptions.Center;
            ButtonSaveProfileInfo.VerticalOptions = LayoutOptions.EndAndExpand;
            ButtonSaveProfileInfo.Margin = 15;
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

                await firebaseHelper.UpdateUser(App.CurrentUser.Login, EntryUserName.Text);

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