using LibraryBLL;
using LibraryCommon;
using LibraryModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryController
{
    [IgnoreAuthorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {

            //如果Cookie中的UserId中有值
            if (Request.Cookies["Callid"] != null)
            {
                string UserId = Request.Cookies["Callid"].Value;
                UserBLL bll = new UserBLL();
                string strDecrypt = CipherTextHelper.Decrypt(UserId);
                Session["Callid"] = strDecrypt;
                return RedirectToAction("Library", "Book");
            }
            return View("Login");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid && bll.IsUserExite(model.ToUserModel()))
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            {
                Session["Callid"] = model.username;
                Response.Cookies.Add(CipherTextHelper.SetCookie(model.username,"Callid"));
                return RedirectToAction("Library", "Book");
            }
            ModelState.AddModelError("Lib_password", "帳號密碼錯誤!!");
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("Callid");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Session["Callid"] = null;
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(LoginViewModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (bll.Add(model.ToUserModel()))//增加用戶
                {
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
    }
}