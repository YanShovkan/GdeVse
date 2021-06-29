using System;
using Xamarin.Forms;

namespace XamarinAppWhereAll.View
{
    public partial class MainPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MeetingListView.ItemsSource = await firebaseHelper.GetAllMeetings();
        }

        public async void ButtonCreateMeeting_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateMeetingPage());
        }

        private async void ButtonOpenMap_Clicked(object sender, EventArgs e)
        {
            var meeting = await firebaseHelper.GetMeeting((sender as Button).Text);
            await Navigation.PushModalAsync(new MapPage(meeting.Address));
        }

        private async void ButtonGetProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage());
        }
    }
}