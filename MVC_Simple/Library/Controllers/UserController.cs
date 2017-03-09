using Library.Authorize;
using LibraryBLL;
using LibraryModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: /User/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(UserModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid && bll.IsUserExite(model))
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            {
                //FormsAuthentication.SetAuthCookie(model.Lib_username, true);
                Session["Callid"] = model.Lib_username;
                SetUserToken(model);
                return RedirectToAction("Library", "Book");
            }
            ModelState.AddModelError("Lib_password", "帳號密碼錯誤!!");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (bll.Add(model))//增加用戶
                {
                    SetUserToken(model);
                    return RedirectToAction("Library", "Book");
                }
                else
                {
                    string message = "";
                    message = "帳戶已存在";
                    ViewBag.message = message;
                }
            }
            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return RedirectToAction("Library", "Book");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        /// <summary>
        /// 設置登入的token　過期30分鐘就冊銷
        /// </summary>
        /// <param name="model"></param>
        private void SetUserToken(UserModel model)
        {
            string userData = "User Longin";
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              model.Lib_username,
              DateTime.Now,
              DateTime.Now.AddMinutes(30),
              true,
              userData,
              FormsAuthentication.FormsCookiePath);
            // 將ticket加密
            string encTicket = FormsAuthentication.Encrypt(ticket);

            // 新增cookie
            Response.Cookies.Add(new
                HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
    }
}