using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WarehouseBLL;

namespace LibraryController
{
    public class ControllerBase: Controller
    {
        /// <summary>
        /// 資料倉儲的User對象
        /// </summary>
        protected IBLL.IUser UserRepositroy = new BLLWarehouse().User;
        #region const名稱
        protected const string USERNAME = "Callid";
        #endregion
        #region 設置目前網站的資訊

        /// <summary>
        /// 用戶資料的Session
        /// </summary>
        protected UserModel UserInfo
        {
            get
            {
                return Session[USERNAME] as UserModel;
            }
            set
            {
                Session[USERNAME] = value;
            }
        }

        /// <summary>
        /// Request的Cookie
        /// </summary>
        protected HttpCookieCollection Cookie
        {
            get
            {
                return Request.Cookies;
            }
        }
        protected HttpCookie UserCookie {
            get {
                return Cookie[USERNAME];
            }
        }
        #endregion
    }
}
