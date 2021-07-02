using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Timers;
using XamarinAppWhereAll.Models;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly FirebaseHelper firebaseHelper = new FirebaseHelper();
        private Position meetingPosition = new Position();
        private readonly string meetingAddress = "";
        private List<UserModel> users;
        private Pin meetingPoint;
        public MapPage(string _meetingAddress)
        {
            InitializeComponent();

            meetingAddress = _meetingAddress;

            DisplayMeetingOnMap(_meetingAddress);
            GetMyCurrentLocation();
            DisplayUsersOnMap(App.CurrentUser.Login);
        }

        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            return status == PermissionStatus.Granted || status == PermissionStatus.Denied ? status : await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }

        private async void GetDistanceBetweenTwoPoints(Location myLocation)
        {
            Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(meetingAddress);
            meetingPosition = approximateLocations.FirstOrDefault();
            Position myPosition = new Position(myLocation.Latitude, myLocation.Longitude);

            Distance distance = Distance.BetweenPositions(meetingPosition, myPosition);

            await DisplayAlert("Information", $"You have {(int)distance.Meters} metres to the meeting point!", "OK");

            await Task.Delay(TimeSpan.FromSeconds(1.25));

            map.MoveToRegion(MapSpan.FromCenterAndRadius(myPosition, Distance.FromMiles(0.05)));
        }

        private async void GetMyCurrentLocation()
        {
            try
            {
                Task<PermissionStatus> status = CheckAndRequestLocationPermission();
                if (status.Equals("Denied"))
                {
                    throw new PermissionException("Permission Denied");
                }

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(60));
                Location location = await Geolocation.GetLocationAsync(request);

                await firebaseHelper.UpdateUser(App.CurrentUser.Login, App.CurrentUser.UserName, location.Longitude, location.Latitude);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine($"\nDATE: {DateTime.Now}, MESSAGE: {fnsEx.Message}\n");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine($"\nDATE: {DateTime.Now}, MESSAGE: {fneEx.Message}\n");
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine($"\nDATE: {DateTime.Now}, MESSAGE: {pEx.Message}\n");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"\nDATE: {DateTime.Now}, MESSAGE: {ioEx.Message}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nDATE: {DateTime.Now}, MESSAGE: {ex.Message}\n");
            }
        }

        private async void DisplayMeetingOnMap(string meetingAddress)
        {
            Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(meetingAddress);
            Position position = approximateLocations.FirstOrDefault();

            if (position.Latitude == 0 && position.Longitude == 0)
            {
                bool result = await DisplayAlert("Confirm Action", "Is your meeting exactly in the Atlantic Ocean?!", "Yes", "No");
                if (!result)
                {
                    Application.Current.MainPage = new MainPage();
                    return;
                }
            }

            meetingPoint = new Pin
            {
                Label = "Meeting point",
                Address = meetingAddress,
                Type = PinType.Place,
                Position = position
            };

            Circle circle = new Circle
            {
                Center = position,
                Radius = new Distance(50),
                StrokeColor = Color.FromHex("#88FF0000"),
                StrokeWidth = 8,
                FillColor = Color.FromHex("#88FFC0CB")
            };

            map.Pins.Add(meetingPoint);
            map.MapElements.Add(circle);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.05)));
        }

        private async void DisplayUsersOnMap(string Login)
        {
            users = await firebaseHelper.GetFilteredUsers(Login);

            foreach (UserModel user in users)
            {
                Pin pin = new Pin
                {
                    Label = "User",
                    Address = user.UserName,
                    Type = PinType.Place,
                    Position = new Position(user.Latitude, user.Longitude)
                };
                map.Pins.Add(pin);
            }

            UserModel currentUser = await firebaseHelper.GetUser(Login);

            GetDistanceBetweenTwoPoints(new Location(currentUser.Latitude, currentUser.Longitude));

            Timer timer = new Timer(20000);
            timer.Elapsed += (sender, e) => HandleTimer();
            timer.Start();
        }

        private async void HandleTimer()
        {
            GetMyCurrentLocation();

            users = await firebaseHelper.GetFilteredUsers(App.CurrentUser.Login);

            map.Pins.Clear();

            foreach (UserModel user in users)
            {
                Pin pin = new Pin
                {
                    Label = "User",
                    Address = user.UserName,
                    Type = PinType.Place,
                    Position = new Position(user.Latitude, user.Longitude)
                };
                map.Pins.Add(pin);
            }
            map.Pins.Add(meetingPoint);
        }
    }
}