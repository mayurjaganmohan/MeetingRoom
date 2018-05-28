using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoom.Models
{
    public class CalendarModel
    {
        public int MeetingRoomNo { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public int Status { get; set; }
    }
}