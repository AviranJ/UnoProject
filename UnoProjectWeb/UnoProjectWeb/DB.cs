
namespace UnoProjectWeb
{

    using System.Data.SqlClient;
    using System;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using System.Web;
    using System.Xml;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Web.Configuration;

    public class DB
    {
        private static string _ConStr = WebConfigurationManager.ConnectionStrings["AConnectionString"].ConnectionString;
        private static SqlConnection conn;
        private static string user;

        public static DataTable ExecuteSelect(string tableName, string sqlSelect, params SqlParameter[] paramsList)
        {
            
             SqlConnection myConnect;
             SqlCommand myCommand;
             SqlDataReader myDataReader;
             myConnect = new SqlConnection(_ConStr);
             myConnect.Open();

             myCommand = new SqlCommand(sqlSelect, myConnect);

            DataTable dataTable = new DataTable();
            dataTable.TableName = tableName;

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {
                if (paramsList != null)
                {
                    foreach (SqlParameter parameter in paramsList)
                    {
                        if (parameter != null)
                        {
                            myCommand.Parameters.Add(parameter);
                        }
                    }
                }

                try
                {
                    conn.Open();
                    myDataReader = myCommand.ExecuteReader();
                    dataTable.Load(myDataReader);

                }
                catch (Exception exception)
                {
                }
                finally
                {
                    conn.Close();
                }
            }

            return dataTable;
        }

        public static void AddWin( string sqlSelect, SqlParameter[] paramsList , string u)
        {
           user = u;

            AsyncCallback myAsyncCallback = new AsyncCallback(EndProcessRequestAddTotalWins);

            conn = new SqlConnection(_ConStr + ";Asynchronous Processing=true");
            conn.Open();

            SqlCommand myCommand = new SqlCommand(sqlSelect, conn);

            if (paramsList != null)
            {
                foreach (SqlParameter parameter in paramsList)
                {
                    if (parameter != null)
                    {
                        myCommand.Parameters.Add(parameter);
                    }
                }
            }

            try
            {
                conn.Open();
                myCommand.BeginExecuteReader(myAsyncCallback, myCommand);

            }
            catch (Exception exception)
            {
            }
        }
        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] paramsList)
        {

            int num = 0;

            conn = new SqlConnection(_ConStr + ";Asynchronous Processing=true");
            AsyncCallback myAsyncCallback = new AsyncCallback(EndProcessRequest);
            SqlCommand command = new SqlCommand(cmdText, conn);

            foreach (SqlParameter parameter in paramsList)
            {
                command.Parameters.Add(parameter);
            }
            try
            {
                command.Connection.Open();
                command.BeginExecuteReader(myAsyncCallback, command);
            }
            catch (Exception exception)
            {
            }

            return num;
        }

        private static void EndProcessRequest(IAsyncResult result)
        {
            conn.Close();
        }

        private static void EndProcessRequestAddTotalWins(IAsyncResult result)
        {

            SqlCommand mySQLCommand = (SqlCommand)result.AsyncState;
            SqlDataReader myDataReader = mySQLCommand.EndExecuteReader(result);
            DataTable dt = new DataTable();

            dt.Load(myDataReader);
            myDataReader.Close();
            conn.Close();

            int totalWins = Int32.Parse(dt.Rows[0]["TotalWins"].ToString());

            string strSql = @"
                               Update Scoreboard set TotalWins=@TotalWins WHERE  PlayerName=@PlayerName ";
            DB.ExecuteNonQuery(strSql, new SqlParameter[] { new SqlParameter("@PlayerName", user), new SqlParameter("@TotalWins", totalWins + 1) });

        }

    }
}
