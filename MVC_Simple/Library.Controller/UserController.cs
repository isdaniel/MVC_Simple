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

        [HttpGet]
        public ActionResult Login()
        {
            if (AuthorizeContext.Current.IsUserLogin())
            {
                return RedirectToAction("Library", "Book");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            UserBLL bll = new UserBLL();
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            if (AuthorizeContext.Current.Login(
                model.ToUserModel(), ModelState.IsValid))
            {
                return RedirectToAction("Library", "Book");
            }
            ModelState.AddModelError("password", "帳號密碼錯誤!!");
            return View();
        }

        public ActionResult Logout()
        {
            AuthorizeContext.Current.Logout();
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
                ViewBag.message = "帳戶已存在";
            }
            return View();
        }
    }
}