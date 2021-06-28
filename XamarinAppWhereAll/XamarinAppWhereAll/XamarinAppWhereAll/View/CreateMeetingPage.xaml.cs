using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateMeetingPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private readonly StackLayout stackLayout = new StackLayout();
        private readonly Label LabelCreateMeeting = new Label();
        private readonly Label LabelAddress = new Label();
        private readonly Entry EntryAddress = new Entry();
        private readonly Label LabelDateStart = new Label();
        private readonly Label LabelTimeStart = new Label();
        private readonly DatePicker DatePickerDate = new DatePicker();
        private readonly TimePicker TimePickerStart = new TimePicker();
        private readonly Label LabelMeetingName = new Label();
        private readonly Entry EntryMeetingName = new Entry();
        private readonly Button ButtonCreateMeeting = new Button();

        public CreateMeetingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            stackLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
            stackLayout.Padding = 15;

            LabelCreateMeeting.Text = "Create an meeting";
            LabelCreateMeeting.FontSize = 36;
            LabelCreateMeeting.TextColor = Color.Black;
            LabelCreateMeeting.Padding = 10;
            LabelCreateMeeting.HorizontalOptions = LayoutOptions.Center;

            LabelAddress.Text = "Address: ";
            LabelAddress.FontSize = 18;
            LabelAddress.TextColor = Color.Black;

            LabelDateStart.Text = "Date of meeting: ";
            LabelDateStart.FontSize = 18;
            LabelDateStart.TextColor = Color.Black;

            LabelTimeStart.Text = "Time of meeting: ";
            LabelTimeStart.FontSize = 18;
            LabelTimeStart.TextColor = Color.Black;

            LabelMeetingName.Text = "Meeting name: ";
            LabelMeetingName.FontSize = 18;
            LabelMeetingName.TextColor = Color.Black;

            ButtonCreateMeeting.Text = "Create";
            ButtonCreateMeeting.FontSize = 18;

            Color color = Color.DeepPink;
            ButtonCreateMeeting.Background = new SolidColorBrush(color);

            ButtonCreateMeeting.TextColor = Color.White;
            ButtonCreateMeeting.HorizontalOptions = LayoutOptions.Center;
            ButtonCreateMeeting.VerticalOptions = LayoutOptions.EndAndExpand;
            ButtonCreateMeeting.Margin = 15;
            ButtonCreateMeeting.Clicked += new EventHandler(ButtonCreateMeeting_Clicked);

            stackLayout.Children.Add(LabelCreateMeeting);
            stackLayout.Children.Add(LabelAddress);
            stackLayout.Children.Add(EntryAddress);
            stackLayout.Children.Add(LabelDateStart);
            stackLayout.Children.Add(DatePickerDate);
            stackLayout.Children.Add(LabelTimeStart);
            stackLayout.Children.Add(TimePickerStart);
            stackLayout.Children.Add(LabelMeetingName);
            stackLayout.Children.Add(EntryMeetingName);
            stackLayout.Children.Add(ButtonCreateMeeting);

            Content = stackLayout;
        }
        private async Task NewItem()
        {
            try
            {
                if (EntryAddress.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the address field!", "OK");
                    return;
                }
                if (EntryMeetingName.Text == null)
                {
                    await DisplayAlert("Warning", "Fill in the name of the meeting!", "OK");
                    return;
                }

                await firebaseHelper.AddMeeting(1, EntryMeetingName.Text, EntryAddress.Text,
                    new DateTime(DatePickerDate.Date.Year, DatePickerDate.Date.Month, DatePickerDate.Date.Day, TimePickerStart.Time.Hours, TimePickerStart.Time.Minutes, TimePickerStart.Time.Seconds));

                Application.Current.MainPage = new MainPage();
            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", e.Message, "OK");
            }
        }

        private void ButtonCreateMeeting_Clicked(object sender, EventArgs e)
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