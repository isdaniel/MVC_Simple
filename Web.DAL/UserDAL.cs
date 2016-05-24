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
        public DataTable User(UserModel User)
        {
            return Sqlhelp.ExecuteDataTable(
                "select * from [user] where [user]=@user and [password]=@password",
                new SqlParameter("@user", User.user_txt),
                new SqlParameter("@password", User.password_txt));
        }
    }
}