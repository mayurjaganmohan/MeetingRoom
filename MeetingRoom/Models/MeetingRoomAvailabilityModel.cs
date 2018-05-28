using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoom.Models
{
    public class MeetingRoomAvailabilityModel
    {
        public int MeetingRoomNo { get; set; }
        public long MeetingRoomBookingNo { get; set; }
        public string MeetingRoomName { get; set; }
        public Dates DateDetails { get; set; }
    }

    public class Dates
    {
        public string MeetingRoomDate { get; set; }
        public string StartTime { get; set; }
        public BookedDetails OtherDetails { get; set; }
    }

    public class BookedDetails
    {
        public string EndTime { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingHost { get; set; }
        public string BookedUserCode { get; set; }
        public string UserEmailId { get; set; }
        public long UserPhoneNo { get; set; }
    }
}