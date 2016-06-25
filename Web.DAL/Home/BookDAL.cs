using MyWeb.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyWeb.DAL
{
    public class BookDAL
    {
        private static readonly BookUtility utility = new BookUtility();

        public void Add(BookModel model)
        {
            utility.Add(model);
        }

        public void Delete(int Id)
        {
            utility.Delete(Id);
        }

        public void Edit(BookModel model)
        {
            utility.Modify(model);
        }

        public BookModel Edit_Model(int Id)
        {
            return utility.Edit_Model(Id);
        }

        public List<BookModel> GetList(string SQLText, params IDataParameter[] parameters)
        {
            return utility.GetList(SQLText, parameters);
        }
    }
}