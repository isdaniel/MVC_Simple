using IBLL;
using LibraryCommon;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WarehouseBLL;

namespace LibraryController
{
    public class LibraryContext
    {

        /// <summary>
        /// 資料倉儲的User對象
        /// </summary>
        public IBLLWarehouse Warehouse = new BLLWarehouse();
        public string ImagePath = ConfigurationManager.AppSettings["ImgaePath"].ToString();


        static LibraryContext _context = null;
        public static LibraryContext Current {
            get {
                if (_context == null)
                {
                    _context = new LibraryContext();
                }
                return _context;
            }
        }


    }
}
