using MyWeb.Common;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Web.DAL
{
    public class BookDAL
    {
        static readonly BookUtility utility = new BookUtility();
        public List<BookModel> GetList(string SQLText,params SqlParameter[] parameters)
        {
            return utility.GetPager(SQLText,parameters);
        }
        public void Edit(BookModel model)
        {
            utility.Edit(model);
        }

        public void Add(BookModel model)
        {
            utility.Add(model);
        }

        public void Delete(int Id)
        {
            utility.Delete(Id);
        }
        public BookModel Edit_Model(int Id)
        {
            return utility.Edit_Model(Id);
        }
    }
}
