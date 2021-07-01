using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Threading;

namespace XamarinAppWhereAll.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly List<Pin> pins = new List<Pin>();
        private readonly string meetingAddress = "";
        private Position meetingPosition = new Position();
        private int timeForRequest = 20;
        private int distanceBetweenTwoPoints;
        public MapPage(string _meetingAddress)
        {
            InitializeComponent();

            meetingAddress = _meetingAddress;

            Task meetingPoint = DisplayMeetingOnMap(_meetingAddress);
            Console.WriteLine($"\n{meetingPoint.Status}\n");

            Task myLocation = GetMyCurrentLocation();
            Console.WriteLine($"\n{myLocation.Status}\n");
        }
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            return status == PermissionStatus.Granted || status == PermissionStatus.Denied ? status : await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        }
        private async Task GetDistanceBetweenTwoPoints(Location myLocation)
        {
            Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(meetingAddress);
            meetingPosition = approximateLocations.FirstOrDefault();
            Position myPosition = new Position(myLocation.Latitude, myLocation.Longitude);

            Distance distance = Distance.BetweenPositions(meetingPosition, myPosition);
            distanceBetweenTwoPoints = (int)distance.Meters;

            await DisplayAlert("Information", $"You have {distanceBetweenTwoPoints} metres to the meeting point!", "OK");

            await Task.Delay(TimeSpan.FromSeconds(1.25));

            map.MoveToRegion(MapSpan.FromCenterAndRadius(myPosition, Distance.FromMiles(0.05)));

            //TimerCallback timeCB = new TimerCallback(PrintTime);

            //Timer time = new Timer(timeCB, null, 0, 1000);
        }
        private async void PrintTime(object state)
        {
            if (timeForRequest != 0)
            {
                LabelMetres.Text = $"You have {distanceBetweenTwoPoints} metres to the meeting point\nNext value update after {timeForRequest} seconds";
                timeForRequest--;
            } 
            else
            {
                if (distanceBetweenTwoPoints > 50)
                {
                    Location location = await Geolocation.GetLocationAsync(new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(60)));
                    Distance distance = Distance.BetweenPositions(meetingPosition, new Position(location.Latitude, location.Longitude));
                    distanceBetweenTwoPoints = (int)distance.Meters;
                }
            }
        }
        private async Task GetMyCurrentLocation()
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

                if (location != null)
                {
                    Console.WriteLine($"\nLATITUDE: {location.Latitude}, LONGITUDE: {location.Longitude}, ALTITUDE: {location.Altitude}\n");
                }

                Task distance = GetDistanceBetweenTwoPoints(location);
                Console.WriteLine($"+++\n{distance.Status}\n");
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
        private async Task DisplayMeetingOnMap(string meetingAddress)
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
    }
}