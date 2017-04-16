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
        /// 返回儲存圖片實體路徑
        /// </summary>
        public static string ImaPhysicalPath
        {
            get {
                return AppSetting("ImaPhysicalPath");
            }
        }
        /// <summary>
        /// 返回圖片Domain URL
        /// </summary>
        public static string ImagePath
        {
            get
            {
                return AppSetting("ImgaePath");
            }
        }

        /// <summary>
        /// 返回appsetting相對應的值
        /// </summary>
        /// <param name="name">add裡面的key</param>
        /// <returns>返回相對應的value</returns>
        private static string AppSetting(string name) {
            return ConfigurationManager.AppSettings[name].ToString();
        }
    }
}
