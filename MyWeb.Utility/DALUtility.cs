using MyWeb.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyWeb.Utility
{
    public abstract class DALUtility<T> : ICRUD<T> where T : new()
    {
        public void Add(T t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into " + TableName());
            sb.Append(Insert_Text(t));
        }

        public void Delete(int id)
        {
            Sqlhelp.ExecuteNonQuery("delete " + TableName() + " where id=@id",
                new SqlParameter("@id", id));
        }

        public List<T> GetList(string SQLText, params SqlParameter[] parameters)
        {
            DataTable Dt = Sqlhelp.ExecuteDataTable(SQLText, parameters);
            return fill_List(Dt);
        }

        public void Modify(T model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("update " + TableName() + " set ");
            sb.Append(Update_Text(model));
            Sqlhelp.ExecuteNonQuery(sb.ToString());
        }

        protected virtual string TableName()
        {
            return "";
        }

        private List<T> fill_List(DataTable Dt)
        {
            List<T> list = new List<T>();
            T model = new T();
            Type type = model.GetType();
            var props = type.GetProperties();
            foreach (DataRow dr in Dt.Rows)
            {
                foreach (var prop in props)
                {
                    prop.SetValue(model, CommonFunctions.IsNull_Value(dr[prop.Name]));
                }
                list.Add(model);
            }
            return list;
        }

        private string Insert_Text(T model)
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

        private string Update_Text(T model)
        {
            StringBuilder sb = new StringBuilder();
            Type type = model.GetType();
            string whereCondition = "";
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                string name = prop.Name;
                if (name != "id")
                    sb.Append(name + "='" + prop.GetValue(model, null) + "',");
                else
                    whereCondition = " Where id='" + prop.GetValue(model, null) + "'";
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(whereCondition);
            return sb.ToString();
        }
    }
}