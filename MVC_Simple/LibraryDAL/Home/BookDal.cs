using Dapper;
using IDAL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public partial class BookDAL: DapperBase , IBookDAL
    {
        public bool Insert(BookModel model)
        {
            string sql = "INSERT INTO dbo.Book (BookLanguage,bookName,BookType,Summary) VALUES  (@BookLanguage,@bookName,@BookType,@Summary)";
            var context= GetDapperContext(sql,true);
            //add parameter.
            context.ExecuteNonQuery();

            return true;
        }

        public void Update(BookModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookModel> GetListBy(Func<BookModel, bool> predicate)
        {
            string sql = "SELECT * FROM dbo.Book";
            var context = GetDapperContext(sql, false);
            //add parameter.
            return context.Query<BookModel>().Where(predicate);
        }

        public int InsertGetId(BookModel model)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(
                "INSERT INTO dbo.Book (BookLanguage,bookName,BookType,Summary) VALUES  (@BookLanguage,@bookName,@BookType,@Summary);");
            sql.Append(
                "SELECT SCOPE_IDENTITY();");
            var context = GetDapperContext(sql.ToString(), true);
            context.Parameters.Add("@BookLanguage", model.BookLanguage, DbType.AnsiString, ParameterDirection.Input, 20);
            context.Parameters.Add("@bookName", model.BookName, DbType.AnsiString, ParameterDirection.Input, 80);
            context.Parameters.Add("@BookType", model.BookType, DbType.AnsiString, ParameterDirection.Input, 20);
            context.Parameters.Add("@Summary", model.summary, DbType.AnsiString, ParameterDirection.Input, 500);
            //add parameter.
            return context.QuerySingleOrDefault<int>();
        }
    }
}