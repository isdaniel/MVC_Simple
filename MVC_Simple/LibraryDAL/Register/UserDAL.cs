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
            string sql = "SELECT * FROM dbo.Users";

            var dapperContext = GetDapperContext(sql, false);

            return dapperContext.Query<UserModel>().Where(predicate);
        }
    }
}