using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class LogsClass
    {
        const string projectName = "LogLibrary";
        const string className = "LogsClass";
        bool BlnReturnSuccess = false;
        string LogFilePath = "";
        public static bool BlnDebugLog(string LogProject, string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string TodaysDate = GetTodaysDate();
            string FileName = LogProject + TodaysDate + ".txt";
            string path = @"D:\Project(.Net)\Trial Samples\MeetingRoom\" + FileName;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "DEBUG");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "DEBUG");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }

            return BlnReturnSuccess;
        }

        public bool BlnErrorLog(string LogProject, string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string TodaysDate = GetTodaysDate();
            string FileName = LogProject + TodaysDate + ".txt";
            string path = @"D:\Project(.Net)\Trial Samples\MeetingRoom\" + FileName;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "ERROR");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "ERROR");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }

            return BlnReturnSuccess;
        }

        public bool BlnWarningLog(string LogProject, string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string TodaysDate = GetTodaysDate();
            string FileName = LogProject + TodaysDate + ".txt";
            string path = @"D:\Project(.Net)\Trial Samples\MeetingRoom\" + FileName;
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "WARNING");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }
            else
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Date Time : " + GetTodaysDateTime());
                    sw.WriteLine("Type : " + "WARNING");
                    sw.WriteLine("Class : " + LogClass);
                    sw.WriteLine("Method : " + LogMethod);
                    sw.WriteLine("Statement : " + LogStatement);
                    sw.WriteLine("Description : " + LogDescription);
                    sw.WriteLine("Addtional Description : " + LogAdditionalDescription);
                }
            }

            return BlnReturnSuccess;
        }

        private string GetTodaysDate()
        {
            const string methodName = "GetTodaysDate";
            string todaysDate = null;
            try
            {
                todaysDate = DateTime.Now.ToString("yyyyMMdd");
                BlnDebugLog(projectName, className, methodName, "Generated Date", "Date : " + todaysDate, null);
            }
            catch (Exception ex)
            {
                BlnErrorLog(projectName, className, methodName, "Exception occured while generating Date", "Exception : " + ex.ToString(), null);
            }
            return todaysDate;
        }

        private string GetTodaysDateTime()
        {
            const string methodName = "GetTodaysDateTime";
            string todaysDateTime = null;
            try
            {
                todaysDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                BlnDebugLog(projectName, className, methodName, "Generated Date", "Date : " + todaysDateTime, null);
            }
            catch (Exception ex)
            {
                BlnErrorLog(projectName, className, methodName, "Exception occured while generating Date", "Exception : " + ex.ToString(), null);
            }
            return todaysDateTime;
        }
    }
}
