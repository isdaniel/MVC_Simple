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
            throw new NotImplementedException();
        }

        public int InsertGetId(BookModel model)
        {
            throw new NotImplementedException();
        }
    }
}