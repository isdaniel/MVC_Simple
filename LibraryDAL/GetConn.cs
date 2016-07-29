using LibraryCommon;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public class GetConn
    {
        private static IDbConnection _SqlConn = null;

        private static string connectString = ConfigurationManager.
            ConnectionStrings["LibraryConn"].ConnectionString;

        private static Logger log = new Logger(typeof(GetConn));

        public static IDbConnection GetInstance()
        {
            try
            {
                if (_SqlConn == null)
                {
                    _SqlConn = new SqlConnection(connectString);
                    _SqlConn.Open();
                    log.WriteSusseccLog("連接成功");
                }
            }
            catch (Exception ex)
            {
                log.WriteErrorLog("連接錯誤", ex);
            }
            return _SqlConn;
        }
    }
}