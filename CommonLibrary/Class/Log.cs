using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Model;
using System.Net;
using Newtonsoft.Json;
using System.Collections;
using System.IO;

namespace CommonLibrary.Class
{
    class Log
    {
        const string projectName = "LogLibrary";
        const string className = "LogsClass";

        private static bool BlnLogMessage(string strMessageType, string strAppPath, string strSource, string strMethod, string strStatement, string strDescription)
        {
            string strAppName = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).ProductName.ToString();
            string strAppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()).ProductVersion.ToString();
            string strIpAddress = string.Empty;
            LogFormat objLogFormatData = new LogFormat();
            ArrayList arrMessage = new ArrayList();

            try
            {
                strAppName = System.Diagnostics.FileVersionInfo.GetVersionInfo(strAppPath).ProductName.ToString();
                strAppVersion = System.Diagnostics.FileVersionInfo.GetVersionInfo(strAppPath).ProductVersion.ToString();
                strIpAddress = GetIP();
            }
            catch { }

            objLogFormatData.DateTime = DateTime.Now.ToString("d MMM yyyy h:mm:ss.fff tt");

            switch (strMessageType.ToUpper())
            {
                case "E":
                    objLogFormatData.Type = "ERROR";
                    break;
                case "I":
                    objLogFormatData.Type = "INFO";
                    break;
                case "W":
                    objLogFormatData.Type = "WARNING";
                    break;
                case "D":
                    objLogFormatData.Type = "DEBUG";
                    break;
                default:
                    objLogFormatData.Type = "UNKNOWN";
                    break;
            }
            objLogFormatData.Server = System.Environment.MachineName.ToString() + " (" + strIpAddress + ")";
            objLogFormatData.Application = strAppName + " " + strAppVersion;
            objLogFormatData.Source = strSource;
            objLogFormatData.Method = strMethod;
            if (strStatement.Length > 0)
            {
                objLogFormatData.Statement = strStatement;
            }
            if (strDescription.ToString().Length > 0)
            {
                objLogFormatData.Description = strDescription;
            }
            string logJson = JsonConvert.SerializeObject(objLogFormatData, Formatting.Indented);
            arrMessage.Add(logJson);
            bool blnReturn = WriteLog(strAppName, arrMessage);
            return blnReturn;

        }
        private static bool WriteLog(string strAppName, ArrayList arlData)
        {

            string strLogFileName = GetLogFileName(strAppName);

            try
            {
                StreamWriter stwLog = new StreamWriter(strLogFileName, true);

                for (int intCount = 0; intCount < arlData.Count; intCount++)
                {
                    stwLog.WriteLine(arlData[intCount].ToString());
                }
                stwLog.WriteLine();
                stwLog.Close();
                stwLog = null;
            }
            catch
            {
                // Is there anything you can do here ???
            }

            return true;

        }
        private static string GetLogFileName(string strFilePrefix)
        {

            string strFolder = System.AppDomain.CurrentDomain.BaseDirectory + "Log\\";
            string strFile = strFolder + strFilePrefix + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

            try
            {
                if (System.IO.Directory.Exists(strFolder) == false)
                {
                    System.IO.Directory.CreateDirectory(strFolder);
                }
            }
            catch
            {
                return "";
            }

            #region Commented - Unused code

            //if (File.Exists(strFile))
            //{
                //string strNewFile = strFile;
                //int intLogCount = 1;
                //while ((new FileInfo(strNewFile)).Length > udcMaxLogFileSize)
                //{
                //strNewFile = strFolder + strFilePrefix + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + intLogCount.ToString("0000") + ".log";
                //if (File.Exists(strNewFile) == false)
                //{
                //    break;
                //}
                //intLogCount++;
                //}
                //strFile = strNewFile;
            //}
            #endregion

            return strFile;

        }
        private static string GetIP()
        {
            string strHostName = "";
            strHostName = Dns.GetHostName();
            IPHostEntry objIPEntry = Dns.GetHostEntry(strHostName);
            IPAddress[] objIPAddress = objIPEntry.AddressList;
            return objIPAddress[objIPAddress.Length - 1].ToString();
        }

        public static bool BlnDebugLog(string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string strAppPath = System.Reflection.Assembly.GetCallingAssembly().Location.ToString();
            return BlnLogMessage("D", strAppPath, LogClass, LogMethod, LogStatement, LogDescription);
        }

        public static bool BlnErrorLog(string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string strAppPath = System.Reflection.Assembly.GetCallingAssembly().Location.ToString();
            return BlnLogMessage("E", strAppPath, LogClass, LogMethod, LogStatement, LogDescription);
        }

        public static bool BlnWarningLog(string LogClass, string LogMethod, string LogStatement, string LogDescription, string LogAdditionalDescription)
        {
            string strAppPath = System.Reflection.Assembly.GetCallingAssembly().Location.ToString();
            return BlnLogMessage("W", strAppPath, LogClass, LogMethod, LogStatement, LogDescription);
        }
    }
}
