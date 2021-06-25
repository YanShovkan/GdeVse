using Xamarin.Forms;
namespace GdeVse.View
{
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout layout = new StackLayout();

            Label label = new Label();
            label.Text = "Настройки";
            label.FontSize = 32;
            label.TextColor = Color.Black;
            label.HorizontalTextAlignment = TextAlignment.Center;
            layout.Children.Add(label);

            Content = layout;
        }
    }
}