using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GdeVse
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout layout = new StackLayout();

            Label labelFullName = new Label();
            labelFullName.Text = "Имя пользователя";
            labelFullName.FontSize = 16;
            labelFullName.TextColor = Color.Black;
            layout.Children.Add(labelFullName);

            Entry FullName = new Entry();
            layout.Children.Add(FullName);

            Content = layout;
        }
    }
}