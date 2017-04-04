using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace LibraryCommon
{
    public class ConfigHelper
    {
        /// <summary>
        /// 返回appsetting相對應的值
        /// </summary>
        /// <param name="name">add裡面的key</param>
        /// <returns>返回相對應的value</returns>
        public static string AppSetting(string name) {
            return ConfigurationManager.AppSettings[name].ToString();
        }
    }
}
