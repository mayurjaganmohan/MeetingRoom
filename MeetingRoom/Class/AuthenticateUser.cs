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
using MeetingRoom.Class;
using Newtonsoft.Json;

namespace MeetingRoom.Class
{
    public class AuthenticateUser
    {
        protected string googleplus_client_id = "1079555062591-elb1cr3e7nc2cq0c0q3g2ne3bvm7emcs.apps.googleusercontent.com";    // Replace this with your Client ID
        protected string googleplus_client_sceret = "AIzaSyDuYC2AXH4G_hRWYMY1-Li5YtwTaC9boio";                                                // Replace this with your Client Secret
        protected string googleplus_redirect_url = "http://localhost:2443/Index.aspx";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        protected string Parameters;
        public bool UserLogin()
        {
            //try
            //{
            //    var url = Request.Url.Query;
            //    if (url != "")
            //    {
            //        string queryString = url.ToString();
            //        char[] delimiterChars = { '=' };
            //        string[] words = queryString.Split(delimiterChars);
            //        string code = words[1];

            //        if (code != null)
            //        {
            //            //get the access token 
            //            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://accounts.google.com/o/oauth2/token");
            //            webRequest.Method = "POST";
            //            Parameters = "code=" + code + "&client_id=" + googleplus_client_id + "&client_secret=" + googleplus_client_sceret + "&redirect_uri=" + googleplus_redirect_url + "&grant_type=authorization_code";
            //            byte[] byteArray = Encoding.UTF8.GetBytes(Parameters);
            //            webRequest.ContentType = "application/x-www-form-urlencoded";
            //            webRequest.ContentLength = byteArray.Length;
            //            Stream postStream = webRequest.GetRequestStream();
            //            // Add the post data to the web request
            //            postStream.Write(byteArray, 0, byteArray.Length);
            //            postStream.Close();

            //            WebResponse response = webRequest.GetResponse();
            //            postStream = response.GetResponseStream();
            //            StreamReader reader = new StreamReader(postStream);
            //            string responseFromServer = reader.ReadToEnd();

            //            GooglePlusAccessToken serStatus = JsonConvert.DeserializeObject<GooglePlusAccessToken>(responseFromServer);

            //            if (serStatus != null)
            //            {
            //                string accessToken = string.Empty;
            //                accessToken = serStatus.access_token;

            //                if (!string.IsNullOrEmpty(accessToken))
            //                {
            //                    // This is where you want to add the code if login is successful.
            //                    // getgoogleplususerdataSer(accessToken);
            //                }
            //            }

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message, ex);
            //    Response.Redirect("index.aspx");
            //}
            return true;
        }

        
    }
}