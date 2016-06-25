using MyWeb.Common;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyWeb.DAL
{
    public class BookUtility : IDAL<BookModel>
    {
        public void Add(BookModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into test ");
            sb.Append(Insert_Text(model));
            Sqlhelp.ExecuteNonQuery(sb.ToString());
        }

        public void Delete(int Id)
        {
            Sqlhelp.ExecuteNonQuery("delete test where id=@id",
                new SqlParameter("@id", Id));
        }

        public BookModel Edit_Model(int Id)
        {
            DataTable Dt = Sqlhelp.ExecuteDataTable(
                "select id,bookName,summary,booklanguage,booktype from test where id=@id",
                new SqlParameter("@id", Id));
            return fill_List(Dt).FirstOrDefault();
        }

        public List<BookModel> GetList(string Sql, params IDataParameter[] parameters)
        {
            DataTable Dt = Sqlhelp.ExecuteDataTable(Sql, parameters);
            return fill_List(Dt);
        }

        public List<BookModel> GetPager(string SQLText,
            params SqlParameter[] paramters)
        {
            DataTable Dt = Sqlhelp.ExecuteDataTable(SQLText, paramters);
            return fill_List(Dt);
        }

        public void Modify(BookModel model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update test set ");
            sb.Append(Update_Text(model));
            Sqlhelp.ExecuteNonQuery(sb.ToString());
        }

        private List<BookModel> fill_List(DataTable Dt)
        {
            List<BookModel> list = new List<BookModel>();
            foreach (DataRow dr in Dt.Rows)
            {
                BookModel model = new BookModel();
                model.BookLanguage = CommonFunctions.IsNull_Value(dr["booklanguage"]);
                model.id = CommonFunctions.IsNull_Value(dr["id"]);
                model.BookType = CommonFunctions.IsNull_Value(dr["booktype"]);
                model.bookName = CommonFunctions.IsNull_Value(dr["bookName"]);
                model.summary = CommonFunctions.IsNull_Value(dr["summary"]);
                list.Add(model);
            }
            return list;
        }

        private string Insert_Text(BookModel model)
        {
            StringBuilder sb = new StringBuilder();
            Type type = model.GetType();
            PropertyInfo[] props = type.GetProperties();
            sb.Append(" (");
            foreach (var prop in props)
            {
                if (prop.Name.ToLower() != "id")
                    sb.Append(prop.Name + ",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            sb.Append(" values ");
            sb.Append("(");
            foreach (var prop in props)
            {
                if (prop.Name.ToLower() != "id")
                    sb.Append("'" + prop.GetValue(model, null) + "',");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(")");
            return sb.ToString();
        }

        private string Update_Text(BookModel model)
        {
            StringBuilder sb = new StringBuilder();
            Type type = model.GetType();
            string whereCondition = "";
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                if (prop.Name != "id")
                    sb.Append(prop.Name + "='" + prop.GetValue(model, null) + "',");
                else
                    whereCondition = " Where id='" + prop.GetValue(model, null) + "'";
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(whereCondition);
            return sb.ToString();
        }
    }
}