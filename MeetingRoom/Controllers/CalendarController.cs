using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingRoom.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public string GetCalendarOnTime(string Location, string Date, string FromTime, string ToTime)
        {
            return null;
        }

        public string GetCalendarOnMeetingRoom(string Location, string MeetingRoomNo)
        {
            return null;
        }
    }
}