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
using LibraryBLL;

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
        protected IUser UserRepositroy = new UserBLL();
        /// <summary>
        /// 資料倉儲的Book對象
        /// </summary>
        protected IBook BookRepositroy = new BookBLL();
        /// <summary>
        /// 資料倉儲的User對象
        /// </summary>
        protected IBookImage BookImageRepositroy = new BookImageBLL();
        /// <summary>
        /// 資料倉儲的Parameter對象
        /// </summary>
        protected IParameterSettingBLL ParameterSettingRepositroy = new ParameterSettingSettingBll(); 
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
        protected HttpCookieCollection Cookie => Request.Cookies;

        protected HttpCookie UserCookie => Cookie[USERNAME];

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
