using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace MyWeb.Common
{
    public class Sqlhelp
    {
        readonly static string connStr = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        /// <summary>
        /// 執行ExecuteNonQuery
        /// </summary>
        /// <param name="sqlstr">SQL語句</param>
        /// <param name="parameters">要傳進來的參數</param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlstr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                {
                    foreach (SqlParameter parmeter in parameters)
                    {
                        cmd.Parameters.Add(parmeter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 通常用在SQL指令上的Count,SUM,MAx
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string sqlstr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                {
                    foreach (SqlParameter parmeter in parameters)
                    {
                        cmd.Parameters.Add(parmeter);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 回傳一個DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sqlstr, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlstr, conn))
                {
                    DataSet ds = new DataSet();
                    cmd.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }
    }
}