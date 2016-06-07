using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyWeb.BLL
{
    public interface IWhere
    {
        string Condition();

        SqlParameter parameter(string content);
    }
}