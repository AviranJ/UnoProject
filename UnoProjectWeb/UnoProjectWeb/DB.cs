
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

        public static HttpContext CurrentContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public static SqlDataAdapter CreateDataAdapter(string strSql, IDbConnection conn)
        {
            return new SqlDataAdapter(strSql, (SqlConnection)conn);
        }

        public static DataTable ExecuteSelect(string sqlSelect, SqlParameter[] paramsList, string tableName)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = tableName;
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                SqlDataAdapter adapter = CreateDataAdapter(sqlSelect, conn);
                if (paramsList != null)
                {
                    foreach (SqlParameter parameter in paramsList)
                    {
                        if (parameter != null)
                        {
                            adapter.SelectCommand.Parameters.Add(parameter);
                        }
                    }
                }

                try
                {
                    conn.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception exception)
                {
                }
                finally
                {
                    adapter.Dispose();
                    adapter = null;

                    conn.Close();
                }
            }

            return dataTable;
        }

        public static DataTable ExecuteSelect(string tableName, string sqlSelect, params SqlParameter[] paramsList)
        {
            return ExecuteSelect(sqlSelect, paramsList, tableName);
        }

        public static DataTable ExecuteSelect(string sqlSelect, SqlParameter param, string tableName)
        {
            return ExecuteSelect(sqlSelect, new SqlParameter[] { param }, tableName);
        }

        public static DataTable ExecuteSelect(string sqlSelect)
        {
            return ExecuteSelect(sqlSelect, new SqlParameter[] { }, "TABLE_SELECT");
        }

        public static string SelectField(string fieldName, string tableName, string whereClause, string orderByClause)
        {
            string tempField = "";

            string strSql = "SELECT " + fieldName + " FROM " + tableName + " ";
            if (whereClause != null && whereClause != "")
            {
                strSql += "WHERE " + whereClause + " ";
            }
            if (orderByClause != null && orderByClause != "")
            {
                strSql += "ORDER BY " + orderByClause + " ";
            }

            try
            {
                DataTable tempDT = ExecuteSelect(strSql, new SqlParameter[] { }, tableName);

                tempField = tempDT.Rows[0][0].ToString().Trim();
            }
            catch (Exception exception)
            {
                throw new Exception(strSql, exception);
            }

            return tempField;
        }


        public static int ExecuteNonQuery(string cmdText)
        {
            return ExecuteNonQuery(cmdText, new SqlParameter[] { });
        }

        public static int ExecuteNonQuery(string cmdText, params SqlParameter[] paramsList)
        {
            return ExecuteNonQuery(cmdText, null, paramsList);
        }

        public static int ExecuteNonQuery(string cmdText, string conStr, params SqlParameter[] paramsList)
        {
            if (String.IsNullOrEmpty(conStr))
            {
                conStr = ConStr;
            }

            int num = 0;

            using (SqlConnection conn = new SqlConnection(conStr))
            {

                SqlCommand command = new SqlCommand(cmdText, conn);

                foreach (SqlParameter parameter in paramsList)
                {
                    command.Parameters.Add(parameter);
                }
                try
                {
                    //DB.WriteTrace("Conns: " + FbConnection.GetPooledConnectionCount(conn).ToString() + "  Pools: " + FbConnection.ConnectionPoolsCount.ToString());

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

        public static int ExecuteNonQueryWithoutException(string cmdText, params SqlParameter[] paramsList)
        {
            int num = 0;

            using (SqlConnection conn = new SqlConnection(ConStr))
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
                    num = -1;
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


        public static string ConStr
        {
            get
            {
                if (_ConStr == null)
                {

                    _ConStr = WebConfigurationManager.ConnectionStrings["AConnectionString"].ConnectionString;
                }

                return _ConStr;
            }
        }

    }
}
