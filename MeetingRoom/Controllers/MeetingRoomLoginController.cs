using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLibrary;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MeetingRoom.Models;
using Newtonsoft.Json;
using CommonLibrary.Class;

namespace MeetingRoom.Controllers
{
    public class MeetingRoomLoginController : Controller
    {
        // GET: MeetingRoomLogin
        public ActionResult Index()
        {
            return View();
        }

        public string LoginUser()
        {
            string returnVal = null;
            bool blnAuthenticateUser = false;
            List<MeetingRoomAvailabilityModel> objList = new List<MeetingRoomAvailabilityModel>();
            #region CODE TO OAUTH USER
            blnAuthenticateUser = true;
            #endregion

            try
            {
                if (blnAuthenticateUser)
                {
                    DbEngine objDataAccess = new DbEngine();
                    string sqlQuery = "select mra.MeetingRoomBookingNo MeetingRoomBookingNo, mra.MeetingRoomNo MeetingRoomNo, mra.MeetingRoomName MeetingRoomName, mra.BookedFrom BookedFrom, mra.BookedTill BookedTill, mra.BookedUserCode BookedUserCode, users.UserEmailId UserEmailId, users.UserFirstName UserFirstName, users.UserLastName UserLastName, users.UserMiddleName UserMiddleName, users.UserPhoneNo UserPhoneNo from tblmeetingroomavailability mra inner join tblusers users on mra.BookedUserCode = users.UserCode inner join meetingroommaster mrm on mrm.MeetingRoomNo = mra.MeetingRoomNo where mra.BookedFrom >= date_sub(now(), interval 6 month)";

                    if (objDataAccess.blnOpenResultSet(sqlQuery))
                    {
                        if (objDataAccess.blnHasRecords)
                        {
                            while (objDataAccess.blnResultsMoveNextRow() == true)
                            {
                                MeetingRoomAvailabilityModel objMra = new MeetingRoomAvailabilityModel();
                                DateTime objDtBookedFrom =  DateTime.Parse(objDataAccess.objResultsValue("BookedFrom").ToString());
                                DateTime objDtBookedTill = DateTime.Parse(objDataAccess.objResultsValue("BookedTill").ToString());
                                string meetingHost = objDataAccess.objResultsValue("UserFirstName").ToString() + " " + objDataAccess.objResultsValue("UserMiddleName").ToString() + " " + objDataAccess.objResultsValue("UserLastName").ToString();
                                string date = objDtBookedFrom.ToString("yyyy-MM-dd");
                                string startTime = objDtBookedFrom.ToString("HH:mm");
                                string endTime = objDtBookedTill.ToString("HH:mm");

                                objMra.MeetingRoomNo = int.Parse(objDataAccess.objResultsValue("MeetingRoomNo").ToString());
                                objMra.MeetingRoomBookingNo = long.Parse(objDataAccess.objResultsValue("MeetingRoomBookingNo").ToString());
                                objMra.MeetingRoomName = objDataAccess.objResultsValue("MeetingRoomName").ToString();

                                objMra.DateDetails.MeetingRoomDate = date; //only date in yyyy-mm-dd format
                                objMra.DateDetails.StartTime = startTime; // only time in 24hrs format 22:00
                                objMra.DateDetails.OtherDetails.EndTime = endTime;// only time in 24hrs format 23:00

                                objMra.DateDetails.OtherDetails.MeetingHost = meetingHost;
                                objMra.DateDetails.OtherDetails.BookedUserCode = objDataAccess.objResultsValue("BookedUserCode").ToString();
                                objMra.DateDetails.OtherDetails.UserEmailId = objDataAccess.objResultsValue("UserEmailId").ToString();
                                objMra.DateDetails.OtherDetails.UserPhoneNo = long.Parse(objDataAccess.objResultsValue("UserPhoneNo").ToString());
                                objList.Add(objMra);
                            }
                        }
                    }
                    returnVal = JsonConvert.SerializeObject(objList);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return returnVal;
        }
    }
}