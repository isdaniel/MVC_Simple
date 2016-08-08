using Dapper;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LibraryDAL
{
    public class UserDAL
    {
        private static UserDAL _Insetance = null;
        private IDbConnection _Conn = GetConn.GetInstance();

        /// <summary>
        /// 使用單例模式
        /// </summary>
        private UserDAL()
        { }

        /// <summary>
        /// 取得UserDal的實體
        /// </summary>
        /// <returns>UserDal實體</returns>
        public static UserDAL GetInstance()
        {
            if (_Insetance == null)
                _Insetance = new UserDAL();
            return _Insetance;
        }

        /// <summary>
        /// 新增一個帳戶
        /// </summary>
        /// <param name="model">UserModel實體</param>
        public void Add(UserModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("insert into UserModel");
            sb.AppendLine("(Lib_username,Lib_password)");
            sb.AppendLine("values");
            sb.AppendLine("(@Lib_username,@Lib_password)");
            _Conn.Execute(sb.ToString(), model);
        }

        /// <summary>
        /// 修改帳戶資訊
        /// </summary>
        /// <param name="model">UserModel實體</param>
        public void Modify(UserModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("update UserModel");
            sb.AppendLine("set lastpassword=lib_password,");
            sb.AppendLine("lib_password=@lib_password,");
            sb.AppendLine("ModifyDate=@ModifyDate");
            sb.AppendLine("where id=@id");
            _Conn.Execute(sb.ToString(), model);
        }

        /// <summary>
        /// 查詢帳戶
        /// </summary>
        /// <param name="Id">帳戶id</param>
        /// <returns>查有資料回傳實體  查無資料回傳null</returns>
        public UserModel SingleSearchByUserName(string username)
        {
            string SqlString = "select * from UserModel where Lib_username=@Lib_username";
            return _Conn.Query<UserModel>(
                SqlString,
                new { Lib_username = username }
                ).FirstOrDefault();
        }
    }
}