using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyWeb.BLL
{
    public class SearchType : IWhere
    {
        public string Condition()
        {
            return " and booktype=@type";
        }

        public SqlParameter parameter(string content)
        {
            return new SqlParameter("@type", content);
        }
    }
}