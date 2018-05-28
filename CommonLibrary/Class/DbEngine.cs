using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary.Class;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;

namespace CommonLibrary.Class
{
    public class DbEngine
    {
        private string ConnectionString = "";
        const string className = "DbEngine";
        private MySqlConnection pconDB = new MySqlConnection();
        private MySqlDataReader data;
        private List<List<Dictionary<string, object>>> plstResultSet = null;
        private string pstrErrorMessage = "";
        private ArrayList arrParams = new ArrayList();
        private int plngRecordsCount;

        #region PROPERTIES
        public bool blnHasRecords
        {
            get
            {
                try
                {
                    if ((lstResultSet != null && lstResultSet.Count > 0) || (data.HasRows))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                }
                return false;
            }
        }

        public string strErrorMessage
        {
            get
            {
                return pstrErrorMessage;
            }
        }
        #endregion

        #region CONSTRUCTORS and DESTRUCTORS
        public DbEngine()
        {
            const string MethodName = "DbEngine - Constructor";
            ConnectionString = Settings.GetValue("dbconnectionstrings", "ConnectionString", "");
            Log.BlnDebugLog(className, MethodName, "Constructor of DbEngine Class", "Fetching the connection string : " + ConnectionString, "");
        }

        ~DbEngine()
        {
            const string MethodName = "DbEngine - Destructor";
            try
            {
                pconDB.Close();
            }
            catch (Exception ex)
            {
                Log.BlnErrorLog(className, MethodName, "Destructor of DbEngine Class", "Exception : " + ex.ToString(), "");
            }
        }
        #endregion

        #region PRIVATE FUNCTIONS
        internal bool OpenConnection()
        {
            const string MethodName = "OpenConnection";
            pstrErrorMessage = "";
            try
            {
                if (pconDB.State == ConnectionState.Open)
                {
                    return true;
                }
                pconDB = new MySqlConnection();
                pconDB.ConnectionString = ConnectionString;
                pconDB.Open();
                while (pconDB.State == ConnectionState.Connecting)
                {
                    // just wait ...
                }
                if (pconDB.State == ConnectionState.Open)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.ToString();
                Log.BlnErrorLog(className, MethodName, "Method thrown exception", "Exception : " + ex.ToString(), "");
            }
            return false;
        }

        internal bool CloseDataReader()
        {
            const string MethodName = "blnCloseDataReader()";

            pstrErrorMessage = "";
            try
            {
                if (data == null)
                {
                    return false;
                }
                if (data.IsClosed == false)
                {
                    data.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.ToString();
                Log.BlnErrorLog(className, MethodName, "Exception thrown", "Exception : " + ex.ToString(), "");
            }
            return false;
        }

        #endregion

        #region Result set related functions
        public bool blnOpenResultSet(string strSQL)
        {
            const string methodName = "blnOpenResultSet";
            pstrErrorMessage = "";

            if (strSQL.Length == 0 || strSQL.IndexOf("--") >= 0 || OpenConnection() == false)
            {
                return false;
            }

            CloseDataReader();

            pstrErrorMessage = "";

            try
            {
                MySqlCommand cmdSQL = pconDB.CreateCommand();

                cmdSQL.CommandText = strSQL;
                cmdSQL.CommandType = CommandType.Text;

                for (int intCount = 0; intCount < arrParams.Count; intCount++) //Adding parameters to the Command object, if any.
                {
                    cmdSQL.Parameters.Add(arrParams[intCount]);
                }

                data = cmdSQL.ExecuteReader();
                plngRecordsCount = data.RecordsAffected;
                cmdSQL = null;
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.Message;
                Log.BlnErrorLog(className, methodName, "Destructor of DbEngine Class", "Exception : " + ex.ToString(), "");
                return false;
            }
            finally
            {
                arrParams.Clear();  //Clear all parameters
            }

            return true;
        }
        public bool blnResultsMoveNextRow()
        {
            const string methodName = "blnResultsMoveNextRow()";
            pstrErrorMessage = "";
            try
            {
                if (data.IsClosed == false)
                {
                    return data.Read();
                }
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.ToString();
                Log.BlnErrorLog(className, methodName, "Destructor of DbEngine Class", "Exception : " + ex.ToString(), "");
            }
            return false;
        }
        public object objResultsValue(string strColumnName)
        {
            return objResultsValue(data.GetOrdinal(strColumnName));
        }
        public object objResultsValue(int intColumnOrdinal)
        {
            const string methodName = "objResultValue(int)";
            pstrErrorMessage = "";
            try
            {
                return data[intColumnOrdinal];
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.ToString();
                Log.BlnErrorLog(className, methodName, "Destructor of DbEngine Class", "Exception : " + ex.ToString(), "");
            }
            return "";
        }
        public List<List<Dictionary<string, object>>> lstResultSet { get { return plstResultSet; } }

        #endregion

        public bool CloseConnection()
        {
            const string MethodName = "blnCloseConnection()";
            try
            {
                pconDB.Close();
                return true;
            }
            catch (Exception ex)
            {
                pstrErrorMessage = ex.ToString();
                Log.BlnErrorLog(className, MethodName, "Destructor of DbEngine Class", "Exception : " + ex.ToString(), "");
            }
            return false;
        }


    }
}
