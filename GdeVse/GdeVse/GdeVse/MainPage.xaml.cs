using Xamarin.Forms;

namespace GdeVse
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout layout = new StackLayout();

            Label label = new Label();
            label.Text = "Где Все?";
            label.FontSize = 32;
            label.TextColor = Color.Black;
            label.HorizontalTextAlignment = TextAlignment.Center;
            layout.Children.Add(label);

            Button btnToProfile = new Button();
            btnToProfile.Text = "Профиль";
            btnToProfile.Clicked += BtnToProfile_Clicked;
            layout.Children.Add(btnToProfile);

            Button btnToMap = new Button();
            btnToMap.Text = "Карта";
            btnToMap.Clicked += BtnToMap_Clicked;
            layout.Children.Add(btnToMap);

            Content = layout;
        }

        private void BtnToMap_Clicked(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private async void BtnToProfile_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage());
        }
    }
}
