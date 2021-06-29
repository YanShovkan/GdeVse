using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.Threading;
using System.IO;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly Geocoder geoCoder = new Geocoder();
        private readonly List<Pin> pins = new List<Pin>();
        private readonly string meetingAddress = "";
        public MapPage(string address)
        {
            InitializeComponent();
            meetingAddress = address;

            //Thread myThread = new Thread(new ThreadStart(SetPosition));
            //myThread.Start();

            var myLocation = GetCurrentLocation();
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(33, 33), Distance.FromMiles(0.05)));
        }
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status == PermissionStatus.Granted || status == PermissionStatus.Denied)
            {
                return status;
            }

            return await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
        private async Task GetDistanceBetweenTwoPoints(string address, Location myLocation)
        {
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
            Position markPosition = approximateLocations.FirstOrDefault();

            Position myPosition = new Position(myLocation.Latitude, myLocation.Longitude);

            Distance distanceBetweenTwoPoints = Distance.BetweenPositions(markPosition, myPosition);

            await DisplayAlert("Information", $"You have {(int)distanceBetweenTwoPoints.Meters} metres to the meeting point!", "OK");

            /*while (true)
            {
                Thread.Sleep(2000);
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(myLocation.Latitude, myLocation.Longitude), Distance.FromMiles(0.05)));
                break;
            }*/
        }
        private async Task GetCurrentLocation()
        {
            try
            {
                var status = await CheckAndRequestLocationPermission();
                if (status.Equals("Denied"))
                {
                    throw new PermissionException("Permission Denied");
                }

                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(30));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"LATITUDE: {location.Latitude}, LONGITUDE: {location.Longitude}, ALTITUDE: {location.Altitude}");
                }

                await GetDistanceBetweenTwoPoints(meetingAddress, location);

                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.05)));
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine($"DATE: {DateTime.Now}, MESSAGE: {fnsEx.Message}");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine($"DATE: {DateTime.Now}, MESSAGE: {fneEx.Message}");
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine($"DATE: {DateTime.Now}, MESSAGE: {pEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"DATE: {DateTime.Now}, MESSAGE: {ioEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DATE: {DateTime.Now}, MESSAGE: {ex.Message}");
            }
        }
        private async void SetPosition()
        {
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

            Pin pin = new Pin
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

            map.Pins.Add(pin);
            map.MapElements.Add(circle);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.05)));

            int count = pins.Where(rec => rec.Address.ToLower().Equals(pin.Address.ToLower())).Count();
            if (count == 0)
            {
                pins.Add(pin);
            }
        }
        private async void GetListPlaces_Clicked(object sender, EventArgs e)
        {
            string result = "";
            foreach (var item in pins)
            {
                result += $"{item.Address}\n";
            }
            await DisplayAlert("Meeting Places", result, "OK");
        }
    }
}