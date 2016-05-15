using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWeb.Common
{
    public static class Common
    {
        public static string IsNull_Value(object obj){  
            if (obj == null)
                obj = "";
           return obj.ToString();
        }
    }
}
