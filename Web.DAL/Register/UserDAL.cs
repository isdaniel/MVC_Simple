using MyWeb.Common;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyWeb.DAL
{
    public class UserDAL
    {
        /// <summary>
        /// 增加一個帳戶
        /// </summary>
        /// <param name="model"></param>
        public void Add(UserModel model)
        {
            Sqlhelp.ExecuteNonQuery(
                "insert into [user] ([user],[password]) values (@user,@password)",
                new SqlParameter("@user", model.user_txt),
                new SqlParameter("@password", model.password_txt));
        }

        /// <summary>
        /// 找尋此帳戶是否存在資料庫
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public DataTable User(UserModel User)
        {
            return Sqlhelp.ExecuteDataTable(
                "select * from [user] where [user]=@user and [password]=@password",
                new SqlParameter("@user", User.user_txt),
                new SqlParameter("@password", User.password_txt));
        }
    }
}