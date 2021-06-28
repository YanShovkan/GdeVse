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
                MeetingId = item.Object.MeetingId,
                MeetingName = item.Object.MeetingName,
                Address = item.Object.Address,
                MeetingStartTime = item.Object.MeetingStartTime
            }).ToList();
        }

        public async Task AddMeeting(int MeetingId, string MeetingName, string Address, DateTime MeetingStartTime)
        {
            var allMeetings = await GetAllMeetings();
            var numberOfMeetings = allMeetings.Where(m => m.MeetingName.ToLower().Equals(MeetingName.ToLower())).Count();
            if (numberOfMeetings != 0)
            {
                throw new Exception("There is already a meeting with this name!");
            }
            await firebase.Child("Meetings").PostAsync(new MeetingModel()
            {
                MeetingId = MeetingId,
                MeetingName = MeetingName,
                Address = Address,
                MeetingStartTime = MeetingStartTime
            });
        }

        public async Task<MeetingModel> GetMeeting(string MeetingName)
        {
            var allMeetings = await GetAllMeetings();
            return allMeetings.Where(m => m.MeetingName == MeetingName).FirstOrDefault();
        }
    }
}