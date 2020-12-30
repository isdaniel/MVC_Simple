using Dapper;
using IDAL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace LibraryDAL
{
    public partial class UserDAL:DapperBase, IUserDAL
    {

        //public void Delete(UserModel model)
        //{
            
        //}

        //public IEnumerable<UserModel> GetListBy(
        //    Func<UserModel, bool> predicate)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("SELECT Password,Username FROM Library_UserInfo");
        //    return _Conn.Query<UserModel>(sb.ToString()).ToList().Where(predicate);
        //}
        ///// <summary>
        ///// 新增一個帳戶
        ///// </summary>
        ///// <param name="model">UserModel實體</param>
        //public void Insert(UserModel model)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("insert into Library_UserInfo");
        //    sb.AppendLine("(Username,Password)");
        //    sb.AppendLine("values");
        //    sb.AppendLine("(@Username,@Password)");
        //    _Conn.Execute(sb.ToString(), model);
        //}
        ///// <summary>
        ///// 修改帳戶資訊
        ///// </summary>
        ///// <param name="model">UserModel實體</param>
        //public void Update(UserModel model)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("update Library_UserInfo");
        //    sb.AppendLine("set lastpassword=lib_password,");
        //    sb.AppendLine("lib_password=@lib_password,");
        //    sb.AppendLine("ModifyDate=@ModifyDate");
        //    sb.AppendLine("where ID=@ID");
        //    _Conn.Execute(sb.ToString(), model);
        //}
        public bool Insert(UserModel model)
        {
            string sql = "INSERT INTO dbo.Users (UserName,PassWord,ModifyDate) VALUES (@UserName,@PassWord,GETDATE())";

            var dapperContext = GetDapperContext(sql, true);

            dapperContext.Parameters.Add("@UserName", model.Username, DbType.AnsiString, ParameterDirection.Input, 120);
            dapperContext.Parameters.Add("@PassWord", model.Password, DbType.AnsiString, ParameterDirection.Input, 25);
            dapperContext.ExecuteNonQuery();
            return true;
        }

        public void Update(UserModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetListBy(Func<UserModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}