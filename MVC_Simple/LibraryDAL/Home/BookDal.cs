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
    public partial class BookDAL:BaseDAL<Library_Book>,IBookDAL
    {
        public int InsertGetId(Library_Book model)
        {
            _Dbcontext.Entry(model).State = System.Data.Entity.EntityState.Added;
            _Dbcontext.SaveChanges();
            return model.id;
        }
    }
}