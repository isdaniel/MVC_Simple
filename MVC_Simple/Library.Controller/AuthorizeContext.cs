using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using LibraryModel;
using LibraryBLL;
using LibraryCommon;

namespace LibraryController
{
    public class AuthorizeContext
    {
        #region 每個執行序中只有一個AuthorizeContext +  public AuthorizeContext Current
        /// <summary>
        /// 每個執行序中只有一個AuthorizeContext
        /// </summary>
        public static AuthorizeContext Current
        {
            get
            {
                var context = CallContext.GetData(typeof(AuthorizeContext).FullName) as AuthorizeContext;
                if (context == null)
                {
                    context = new AuthorizeContext();
                }
                return context;
            }
        }
        #endregion

        #region 設置目前網站的資訊
        /// <summary>
        /// 當前頁面的上下文
        /// </summary>
        private HttpContext _httpContext = HttpContext.Current;
        /// <summary>
        /// 請求期間讀取用戶端送出的 HTTP 值。
        /// </summary>
        public HttpRequest Request {
            get {
                return _httpContext.Request;
            }
        }
        /// <summary>
        /// HTTP 回應資訊
        /// </summary>
        public HttpResponse Response {
            get {
                return _httpContext.Response;
            }
        }

        /// <summary>
        /// 取得目前工作階段狀態物件的參考。
        /// </summary>
        public HttpSessionState Session
        {
            get
            {
                return _httpContext.Session;
            }
        }
        /// <summary>
        /// 用戶資料的Session
        /// </summary>
        private UserModel UserName
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
        public HttpCookieCollection Cookie
        {
            get
            {
                return Request.Cookies;
            }
        }
        #endregion

        #region Session使用者名稱 + USERNAME
        /// <summary>
        /// Session使用者名稱
        /// </summary>
        private const string USERNAME = "Callid";
        #endregion

        //-----------------登入操作------------------------------//
        #region 判斷是否在cookie中有userID，如果有存入Session中 +  bool IsUserLogin()
        /// <summary>
        /// 判斷是否在cookie中有userID，如果有存入Session中
        /// </summary>
        /// <returns></returns>
        public bool IsUserLogin()
        {
            //如果Cookie中的UserId中有值
            if (Cookie[USERNAME] != null)
            {
                UserBLL bll = new UserBLL();
                string UserId = Cookie[USERNAME].Value;
                //將UserId解密
                string UserIdDecrypt = CipherTextHelper.Decrypt(UserId);
                var user = bll.GetUserByUsername(UserIdDecrypt);
                //如果有查詢到User
                if (user != null)
                {
                    //將user訊息存入Session中
                    UserName = user;
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 判斷此帳號密碼和前台驗證是否合法 + bool Login(UserModel model, bool IsValid)
        /// <summary>
        /// 判斷此帳號密碼和前台驗證是否合法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IsValid"></param>
        /// <returns></returns>
        public bool Login(UserModel model, bool IsValid)
        {
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            UserBLL bll = new UserBLL();
            var user = bll.GetUser(model);
            if (IsValid && user != null)
            {
                UserName = user;
                //將使用者Id加密傳到前端
                Response.Cookies.Add(CipherTextHelper.SetCookie(model.Lib_username, USERNAME));
                return true;
            }
            return false;
        }
        #endregion

        #region 使用者登出 + void Logout()
        /// <summary>
        /// 使用者登出
        /// </summary>
        public void Logout()
        {
            HttpCookie cookie = new HttpCookie(USERNAME);
            //將使用者的cookie註銷
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            UserName = null;
        }
        #endregion
    }
}
