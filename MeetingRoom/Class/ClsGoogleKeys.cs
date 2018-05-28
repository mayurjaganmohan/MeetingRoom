using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingRoom.Class
{
    public class ClsGoogleKeys
    {
        protected string googleplus_client_id = "1079555062591-elb1cr3e7nc2cq0c0q3g2ne3bvm7emcs.apps.googleusercontent.com";    // Replace this with your Client ID
        protected string googleplus_client_sceret = "AIzaSyDuYC2AXH4G_hRWYMY1-Li5YtwTaC9boio";                                                // Replace this with your Client Secret
        protected string googleplus_redirect_url = "http://localhost:2443/Index.aspx";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
        public string Parameters;
    }
}