using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyWeb.BLL
{
    public class ConditionStrategy
    {
        private string _content;
        private IWhere _where;

        public ConditionStrategy(IWhere where, string content)
        {
            this._where = where;
            this._content = content;
        }

        public string getCondition()
        {
            return _content.Length > 0 ? _where.Condition() : "";
        }

        public void getParameter(ref List<SqlParameter> paras)
        {
            if (_content.Length > 0)
            {
                paras.Add(_where.parameter(_content));
            }
        }
    }
}