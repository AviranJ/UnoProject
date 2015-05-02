
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
        private SqlConnection conn;

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

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] paramsList)
        {

            int num = 0;

            using (SqlConnection conn = new SqlConnection(_ConStr))
            {

                SqlCommand command = new SqlCommand(cmdText, conn);

                foreach (SqlParameter parameter in paramsList)
                {
                    command.Parameters.Add(parameter);
                }
                try
                {
                    command.Connection.Open();
                    num = command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                }
                finally
                {
                    command.Dispose();
                    command = null;
                    conn.Close();
                }
            }

            return num;
        }

    }
}
