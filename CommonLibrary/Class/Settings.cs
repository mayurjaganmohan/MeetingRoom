using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using LogLibrary;
using System.Xml;
using CommonLibrary.Class;

namespace CommonLibrary.Class
{
    public class Settings
    {
        const string className = "Settings";
        static XmlDocument xmlDoc = new XmlDocument();
        static string strFileName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"..\MeetingRoom.config";
        public static string GetValue(string section, string keyName, string defaultValue)
        {
            const string methodName = "GetValue";
            try
            {
                XmlNode xmlSettings, xmlData;
                xmlSettings = xmlDoc.SelectSingleNode("Settings/" + section);
                if (xmlSettings == null)
                {
                    return defaultValue;
                }
                xmlData = xmlDoc.SelectSingleNode("Settings/" + section + "/" + keyName);
                if (xmlData == null)
                {
                    return defaultValue;
                }
                return xmlData.InnerText;
            }
            catch (Exception ex)
            {
                Log.BlnErrorLog(className, methodName, "Exception caught", "Exception : " + ex.ToString(), "");
            }
            return defaultValue;
        }
    }
}
