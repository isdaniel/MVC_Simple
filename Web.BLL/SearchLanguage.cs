using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyWeb.BLL
{
    public class SearchLanguage : IWhere
    {
        public string Condition()
        {
            return " and BookLanguage=@language";
        }

        public SqlParameter parameter(string content)
        {
            return new SqlParameter("@language", content);
        }
    }
}