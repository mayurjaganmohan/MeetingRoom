using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using CommonLibrary;
using System.IO;
using System.Diagnostics;
using System.Data;
using CommonLibrary.Class;

namespace DataAccessLibrary
{
    public class DataAccess
    {
        bool blnReturn = false;
        private MySqlConnection connection;
        public int intAffectedRows;
        public bool blnHasRecords;

        //try to implement interface or abstract
        public DataAccess()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = Settings.GetValue("dbconnectionstrings", "mysqlconnectionstring", "");
            if (connectionString != "")
            {
                connection = new MySqlConnection(connectionString);
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //Error log Cannot connect to server.
                        break;

                    case 1045:
                        //error log Invalid user name and/or password.
                        break;
                }
                return false;
            }
        }
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                //error log
                return false;
            }
        }
        public void ExecuteNonQuery(string query)
        {
            //Method for insert, update, delete
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                intAffectedRows = cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public List<string>[] Select(string query)
        {
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["name"] + "");
                    list[2].Add(dataReader["age"] + "");
                }

                dataReader.Close();
                this.CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        public bool blnOpenResultSet(string query)
        {
            try
            {
                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool blnResultsMoveNextRow()
        {
            return false;
        }

        #region INCOMPLETE METHODS
        public bool BlnParamClear()
        {
            //MySqlParameter.
            return false;
        }

        public bool blnParamAdd(ParameterDirection spdParameterDirection, string strParameterName, SqlDbType sdtParameterType, int intParameterSize, object objParameterValue)
        {
            return false;
        }
        #endregion

        #region UNUSED METHODS
        //Backup
        public void Backup()
        {
            throw new MethodAccessException();
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                //psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                //    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                //ERROR log
            }
        }

        //Restore
        public void Restore()
        {
            throw new MethodAccessException();
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                //psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                //    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                //error log
            }
        }
        #endregion
    }
}
