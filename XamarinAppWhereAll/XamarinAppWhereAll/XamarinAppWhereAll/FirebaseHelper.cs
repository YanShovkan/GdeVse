using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamarinAppWhereAll.Models;

namespace XamarinAppWhereAll
{
    public class FirebaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://xamarinapp-317906-default-rtdb.firebaseio.com/");
        public async Task<List<MeetingModel>> GetAllMeetings()
        {
            return (await firebase.Child("Meetings").OnceAsync<MeetingModel>()).Select(item => new MeetingModel
            {
                MeetingName = item.Object.MeetingName,
                Address = item.Object.Address,
                MeetingStartTime = item.Object.MeetingStartTime
            }).ToList();
        }
        public async Task AddMeeting(string MeetingName, string Address, DateTime MeetingStartTime)
        {
            List<MeetingModel> allMeetings = await GetAllMeetings();
            int numberOfMeetings = allMeetings.Where(m => m.MeetingName.ToLower().Equals(MeetingName.ToLower())).Count();
            if (numberOfMeetings != 0)
            {
                throw new Exception("There is already a meeting with this name!");
            }
            await firebase.Child("Meetings").PostAsync(new MeetingModel()
            {
                MeetingName = MeetingName,
                Address = Address,
                MeetingStartTime = MeetingStartTime
            });
        }
        public async Task<MeetingModel> GetMeeting(string MeetingName)
        {
            List<MeetingModel> allMeetings = await GetAllMeetings();
            return allMeetings.FirstOrDefault(m => m.MeetingName == MeetingName);
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
            return (await firebase.Child("Users").OnceAsync<UserModel>()).Select(item => new UserModel
            {
                UserName = item.Object.UserName,
                Login = item.Object.Login,
                Password = item.Object.Password,
                Latitude = item.Object.Latitude,
                Longitude = item.Object.Longitude,
                IsActive = item.Object.IsActive
            }).ToList();
        }

        public async Task<List<UserModel>> GetFilteredUsers(string Login)
        {
            return (await firebase.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.IsActive && u.Object.Latitude != 0 && u.Object.Longitude != 0 && u.Object.Login != Login).Select(item => new UserModel
            {
                UserName = item.Object.UserName,
                Login = item.Object.Login,
                Latitude = item.Object.Latitude,
                Longitude = item.Object.Longitude,
            }).ToList();
        }

        public async Task AddUser(string UserName, string Login, string Password, double Latitude, double Longitude, bool IsActive)
        {
            List<UserModel> allUsers = await GetAllUsers();
            int numberOfUsers = allUsers.Where(u => u.Login.ToLower().Equals(Login.ToLower())).Count();
            if (numberOfUsers != 0)
            {
                throw new Exception("There is already a user with this login!");
            }
            await firebase.Child("Users").PostAsync(new UserModel()
            {
                UserName = UserName,
                Login = Login,
                Password = Password,
                Latitude = Latitude,
                Longitude = Longitude,
                IsActive = IsActive
            });
        }

        public async Task UpdateUser(string Login, string UserName, double Longitude, double Latitude)
        {
            FirebaseObject<UserModel> toUpdateUser = (await firebase.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == Login).FirstOrDefault();
            double longitude, latitude;
            if (Longitude != -1 && Latitude != -1)
            {
                longitude = Longitude;
                latitude = Latitude;
            }
            else
            {
                longitude = toUpdateUser.Object.Longitude;
                latitude = toUpdateUser.Object.Latitude;
            }
            await firebase.Child("Users").Child(toUpdateUser.Key).PutAsync(new UserModel()
            {
                UserName = UserName,
                Login = toUpdateUser.Object.Login,
                Password = toUpdateUser.Object.Password,
                Longitude = longitude,
                Latitude = latitude,
                IsActive = toUpdateUser.Object.IsActive
            });
        }

        public async Task<UserModel> GetUser(string Login)
        {
            List<UserModel> allUsers = await GetAllUsers();
            return allUsers.FirstOrDefault(m => m.Login == Login);
        }

        public async Task CheckUserInDatabase(string Login, string Password, bool IsActive)
        {
            FirebaseObject<UserModel> user = (await firebase.Child("Users").OnceAsync<UserModel>()).Where(u => u.Object.Login == Login && u.Object.Password == Password).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Wrong login or password!");
            }
            await firebase.Child("Users").Child(user.Key).PutAsync(new UserModel()
            {
                UserName = user.Object.UserName,
                Login = user.Object.Login,
                Password = user.Object.Password,
                Longitude = user.Object.Longitude,
                Latitude = user.Object.Latitude,
                IsActive = IsActive
            });
        }
    }
}