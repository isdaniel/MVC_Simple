using MyWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Utility
{
    public class SQLContent
    {
        private object _model;
        private ECRUD_Status _status;

        public SQLContent(object model, ECRUD_Status status)
        {
            _status = status;
            _model = model;
        }

        public string getFirstSection()
        {
            StringBuilder sb = new StringBuilder();
            Type type = _model.GetType();
            PropertyInfo[] props = type.GetProperties();
            switch (_status)
            {
                case ECRUD_Status.insert:
                    sb.Append(" (");
                    foreach (var prop in props)
                    {
                        if (prop.Name.ToLower() != "id")
                            sb.Append(prop.Name + ",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append(")");
                    break;

                case ECRUD_Status.update:
                    foreach (var prop in props)
                    {
                        if (prop.Name.ToLower() != "id")
                            sb.Append(prop.Name + ",");
                    }
                    break;
            }

            return sb.ToString();
        }
    }
}