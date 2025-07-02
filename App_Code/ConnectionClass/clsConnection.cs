using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using System.Configuration;
using TripleITTransaction;

namespace TripleITConnection
{
    public class clsConnection
    {
        public static string usertype = "";
        public static int UserID ;

        public clsConnection()
        {
            //
            // TODO: Add constructor logic here
            //
        }


      // Make Connection String Here
      // Lalit Kumar Verma 16-02-09  
      public  string ConnectString
        {
            get
            {
               
                // Connection in FTP
                    string strConnection = @"Data Source=216.48.177.70;Initial Catalog=WorldLifeCareDB;Persist Security Info=True;User Id=WorldLifeCare_DB;Password=K&I80k6?Mglgqvko; connection Timeout=20000;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=2000;Pooling=true;";
            
         
                clsSecurity.SetConnectionStatus("O"); // For Offline Only Numeric
                //clsSecurity.SetConnectionStatus("O"); // For On Line With Alpha-Numeric
                return strConnection;
            }
        }


       // Lalit Kumar Verma 16-02-09  
      public IDataReader GetUserInformation(string ProcedureName, params SqlParameter[] Parameters)
        {
            IDataReader clsReader = null;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;
             
            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);
            //Open connection
            clsConn.Open();
            try
            {
                clsReader = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException x)
            {
                //Log error messages
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 1);

            }

            clsCommand = null;
            clsConn = null;

            return clsReader;
        }

        // Lalit Kumar Verma 16-02-09  
        public int GetUserID(string ProcedureName, params SqlParameter[] Parameters)
        {
            int output = 0;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;
            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);
            clsConn.Open();
            try
            {
                output = Convert.ToInt32(clsCommand.ExecuteScalar());
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 2);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;

            return output;
        }

        // Lalit Kumar Verma 16-02-09  
        public int Login(string ProcedureName, params SqlParameter[] Parameters)
        {
          int output = 0; //= 0;
           // SqlConnection clsConn = new SqlConnection(Connection());
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;
            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);
          
            clsConn.Open();
            try
            {
                SqlDataReader sdr = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (sdr.Read())
                {
                    usertype = Convert.ToString(sdr["USERTYPE"]);

                    output = 1;
                }
                //output = Convert.ToInt32(clsCommand.ExecuteScalar());
            }
            catch (SqlException x)
            {
                //return 0;
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 3);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;

            return output;
        }

        // Lalit Kumar Verma 16-02-09  
        public string GetString(string ProcedureName, params SqlParameter[] Parameters)
        {
            string output = "";
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);
            SqlDataReader clsReader;

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            //Open connection
            clsConn.Open();
            try
            {
                //Populate Data Reader
                clsReader = clsCommand.ExecuteReader();

                //If dreader is non-empty object and if record of interest is non-null 
                if (clsReader.Read())
                    if (clsReader.GetValue(0) != DBNull.Value)
                        output = clsReader.ToString();

                //Close data reader
                clsReader.Close();
            }
            catch (SqlException x)
            {
                //Log error messages
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 4);
            }

            //Close DB Connection
            clsConn.Close();

            clsCommand = null;
            clsConn = null;

            return output;
        }

        // Return Data Reader 
        // Lalit Kumar Verma 16-02-09  
        public IDataReader ReturnDataReader(string ProcedureName, params SqlParameter[] Parameters)
        {

            IDataReader clsReader = null;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);
            else
            {
                clsReader = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            //Open connection
            clsConn.Open();

            try
            {
                clsReader = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int j = clsReader.FieldCount;


            }
            catch (SqlException x)
            {
                //Log error messages
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 5);
            }

            clsCommand = null;
            clsConn = null;
            clsConn.Close();

            return clsReader;
        }

        // Return Data Tables with Procedure
        // Lalit Kumar Verma 16-02-09  
        public DataTable ReturnDataTable(string ProcedureName, params SqlParameter[] Parameters)
        {
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);
            clsCommand.CommandTimeout = 2000;
            DataTable clsDataTable = new DataTable();
            IDataReader clsDataReader;
            //DataSet ds = new DataSet();
            

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            clsConn.Open();

            try
            {
                clsDataReader = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int t = clsDataReader.FieldCount;
                if (clsDataReader != null)
                {
                    clsDataTable.Load(clsDataReader);
                }

            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 6);
                return null;
            }

            clsCommand = null;
            clsConn = null;

            return clsDataTable;
        }

        // Return Data Tables with Sql
        // Lalit Kumar Verma 16-02-09  
        public DataTable ReturnDataTableSql(string cSql)
        {
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(cSql, clsConn);
            DataTable clsDataTable = new DataTable();
            IDataReader clsDataReader;

            clsCommand.CommandType = CommandType.Text;
            clsConn.Open();

            try
            {
                clsCommand.CommandTimeout = 2000;
                clsDataReader = clsCommand.ExecuteReader(CommandBehavior.CloseConnection);
                int t = clsDataReader.FieldCount;
                if (clsDataReader != null)
                {
                    clsDataTable.Load(clsDataReader);
                }
            }
            catch (SqlException x)
            {
                WriteToEventLog(cSql + "\n" + x.ToString(), 6);
                return null;
            }

            clsCommand = null;
            clsConn = null;

            return clsDataTable;
        }

        // Return Data Tables With Xml
        // Lalit Kumar Verma 16-02-09  
        public DataTable ReturnXmlDataTable(string ProcedureName, params SqlParameter[] Parameters)
        {
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);
            DataTable clsDataTable = new DataTable();
            //IDataReader clsDataReader;
            DataSet ds = new DataSet();

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            clsConn.Open();

            try
            {
                XmlReader xr = clsCommand.ExecuteXmlReader();
                if (xr.Read())
                {
                    ds.ReadXml(xr, XmlReadMode.InferSchema);
                    if (ds.Tables[0].Columns.Count != 0)
                    {
                        clsDataTable = ds.Tables[0];
                    }
                }
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 6);
                return null;
            }

            clsCommand = null;
            clsConn = null;

            return clsDataTable;
        }

        // Return Xml Reader
        // Lalit Kumar Verma 16-02-09  
        public XmlReader ReturnXmlReader(string ProcedureName, params SqlParameter[] Parameters)
        {
            XmlReader clsReader = null;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            //Open connection
            clsConn.Open();

            try
            {
                clsReader = clsCommand.ExecuteXmlReader();
            }
            catch (SqlException x)
            {
                //Log error messages
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 7);
            }

            clsCommand = null;
            clsConn = null;

            return clsReader;
        }

        // Return Data Table With Paging
        // Lalit Kumar Verma 16-02-09  
        public DataTable GetDataTableWithPaging(string ProcedureName, int sIndex, int PageSize, params SqlParameter[] Parameters)
        {
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);
            SqlDataAdapter clsDataAdapter = new SqlDataAdapter(clsCommand);
            DataSet clsDataSet = new DataSet();

            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            try
            {
                clsDataAdapter.Fill(clsDataSet, sIndex, PageSize, "tb");
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 8);
                return null;
            }

            DataTable clsDataTable = clsDataSet.Tables[0];

            clsDataAdapter = null;
            clsDataSet = null;
            clsCommand = null;
            clsConn = null;

            return clsDataTable;
        }

        // Return Record Count
        // Lalit Kumar Verma 16-02-09  
        public int GetRecordCount(string ProcedureName)
        {
            int output = 0;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandType = CommandType.StoredProcedure;

            clsConn.Open();
            try
            {
                output = Convert.ToInt32(clsCommand.ExecuteScalar());
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 9);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;

            return output;
        }

        // Execute Procedure with Add/Update/Delete
        // Lalit Kumar Verma 16-02-09  
        public  int ExecuteProcedure(string ProcedureName, params SqlParameter[] Parameters)
        {
            int intErr = 0;
            int temp = 0;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandText = ProcedureName;
            clsCommand.CommandTimeout = 2000;
            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);

            clsConn.Open();
            try
            {
                temp = clsCommand.ExecuteNonQuery();
                return temp;
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 10);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;
            return intErr;
        }

        // Execute Sql Query with Add/Update/Delete
        // Lalit Kumar Verma 16-02-09  
        public int ExecuteSqlQuery(string clsSql)
        {
            int intErr = 0;
            int temp = 0;
            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(clsSql, clsConn);

            clsCommand.CommandText = clsSql;
            clsCommand.CommandTimeout = 2000;
            clsCommand.CommandType = CommandType.Text;
            clsConn.Open();
            try
            {
                temp = clsCommand.ExecuteNonQuery();
                return temp;
            }
            catch (SqlException x)
            {
                //intErr = 1;
                WriteToEventLog(clsSql + "\n" + x.ToString(), 11);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;
            return intErr;
        }


        // Execute Procedure with Last ID
        // Lalit Kumar Verma 16-02-09  
        public Int32 ExecuteProcedureLastID(string ProcedureName, params SqlParameter[] Parameters)
        {
            int intErr = 0;
            Int32  temp = 0;

            SqlConnection clsConn = new SqlConnection(ConnectString);
            SqlCommand clsCommand = new SqlCommand(ProcedureName, clsConn);

            clsCommand.CommandText = ProcedureName;
            clsCommand.CommandType = CommandType.StoredProcedure;

            if (Parameters != null)
                foreach (SqlParameter item in Parameters)
                    clsCommand.Parameters.Add(item);
            clsCommand.Parameters["@GetLastId"].Direction = ParameterDirection.Output;
            clsConn.Open();
            try
            {
                temp = clsCommand.ExecuteNonQuery();
                //if (temp <=1)
                //{ }
                //else
                //{
                temp = Convert.ToInt32(clsCommand.Parameters["@GetLastId"].Value.ToString());
               // }
                return temp;
            }
            catch (SqlException x)
            {
                WriteToEventLog(ProcedureName + "\n" + x.ToString(), 10);
            }
            clsConn.Close();
            clsCommand = null;
            clsConn = null;
            return intErr;
        }

        // Write Erro Log Files
        // Lalit Kumar Verma 16-02-09  
        private int WriteToEventLog(string msg, int EventID)
        {
            try
            {
                EventLog myEventLog = new EventLog("TripleIT");
                myEventLog.Source = "TripleIT";
                myEventLog.WriteEntry(msg, EventLogEntryType.Warning, EventID);
                myEventLog = null;
            }
            catch
            {
                return 1;
            }

            return 0;
        }

    }
}