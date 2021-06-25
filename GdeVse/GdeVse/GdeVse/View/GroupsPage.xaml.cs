using System.Collections.Generic;
using Xamarin.Forms;

namespace GdeVse.View
{
    public partial class GroupsPage : ContentPage
    {

        private List<string> groups = new List<string>();
        public GroupsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            StackLayout layout = new StackLayout();

            Label label = new Label();
            label.Text = "Группы";
            label.FontSize = 32;
            label.TextColor = Color.Black;
            label.HorizontalTextAlignment = TextAlignment.Center;
            layout.Children.Add(label);

            foreach (var group in groups)
            {
                
            }


            Button btnCreateGroup = new Button();
            btnCreateGroup.Text = "Создать новую группу";
            btnCreateGroup.Clicked += BtnCreateGroup_Clicked; ;
            layout.Children.Add(btnCreateGroup);

            

            Content = layout;
        }

        private void BtnCreateGroup_Clicked(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}