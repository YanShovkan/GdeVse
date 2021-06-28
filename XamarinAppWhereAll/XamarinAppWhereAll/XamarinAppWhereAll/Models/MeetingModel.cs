using System;

namespace XamarinAppWhereAll.Models
{
    public class MeetingModel
    {
        public int MeetingId { get; set; }

        public string MeetingName { get; set; }

        public string Address { get; set; }

        public DateTime MeetingStartTime { get; set; }
    }
}