using IBLL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WarehouseBLL;

namespace LibraryController
{
    public class ControllerBase: Controller
    {
        #region 快取 + Cache
        /// <summary>
        /// 快取
        /// </summary>
        protected ObjectCache Cache = MemoryCache.Default; 
        #endregion
        #region 資料倉儲
        /// <summary>
        /// 資料倉儲的User對象
        /// </summary>
        protected IUser UserRepositroy = new BLLWarehouse().User;
        /// <summary>
        /// 資料倉儲的Book對象
        /// </summary>
        protected IBook BookRepositroy = new BLLWarehouse().Book;
        /// <summary>
        /// 資料倉儲的User對象
        /// </summary>
        protected IBookImage BookImageRepositroy = new BLLWarehouse().BookImage;
        /// <summary>
        /// 資料倉儲的Parameter對象
        /// </summary>
        protected IParameterBLL ParameterRepositroy = new BLLWarehouse().Parameter; 
        #endregion
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
        #region 登出使用者清除Session和Cookie + void LogoutUser()
        /// <summary>
        /// 登出使用者清除Session和Cookie
        /// </summary>
        protected void LogoutUser()
        {
            HttpCookie cookie = new HttpCookie(USERNAME);
            //將使用者的cookie和Session註銷
            Session[USERNAME] = null;
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
        } 
        #endregion

    }
}
