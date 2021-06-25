using Xamarin.Forms;

namespace GdeVse.View
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout layout = new StackLayout();

            Label label = new Label();
            label.Text = "Профиьль";
            label.FontSize = 32;
            label.TextColor = Color.Black;
            label.HorizontalTextAlignment = TextAlignment.Center;
            layout.Children.Add(label);

            Label labelFullName = new Label();
            labelFullName.Text = "Имя пользователя: ";
            labelFullName.FontSize = 16;
            labelFullName.TextColor = Color.Black;
            layout.Children.Add(labelFullName);

            Entry FullName = new Entry();
            layout.Children.Add(FullName);

            Button btnOptions = new Button();
            btnOptions.Text = "Настройки";
            btnOptions.Clicked += BtnOptions_Clicked;
            layout.Children.Add(btnOptions);

            Content = layout;
        }

        private void BtnOptions_Clicked(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}