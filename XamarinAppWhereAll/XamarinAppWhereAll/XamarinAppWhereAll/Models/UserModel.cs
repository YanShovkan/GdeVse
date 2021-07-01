
namespace XamarinAppWhereAll.Models
{
    public class UserModel
    {
        public string UserName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
        public bool IsActive { get; set; }
    }
}