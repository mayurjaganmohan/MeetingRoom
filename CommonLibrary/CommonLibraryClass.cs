using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LogLibrary;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CommonLibrary
{
    public class CommonLibraryClass
    {
        const string ProjectName = "CommonLibraryClass";
        const string ClassName = "CommonLibraryClass";
        const string ConfigFilePath = "..\\..\\Config.xml";
        public static string GetValue(string ParentTag, string Key, string DefaultValue)
        {
            const string MethodName = "GetValue";
            LogsClass objLogLibrary = new LogsClass();
            string Value = DefaultValue;
            try
            {
                XPathDocument doc = new XPathDocument(ConfigFilePath);
                foreach (XPathNavigator child in doc.CreateNavigator().Select("settings/*"))
                {
                    Value = child.SelectSingleNode("value").Value;
                }

                objLogLibrary.BlnDebugLog(ProjectName, ClassName, MethodName, "Reading XML data from Config.xml", "Key : " + Key + " | Value : " + Value, null);
            }
            catch (Exception ex)
            {
                objLogLibrary.BlnErrorLog(ProjectName, ClassName, MethodName, "Exception occured while reading data from Config.XML", "Exception : " + ex.ToString(), null);
            }
            return Value;
        }
    }
}
