using LibraryBLL;
using LibraryModel;
using MVC.Filter;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MVC.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class UserController : Controller
    {
        // GET: /User/
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model, string returnUrl)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (bll.IsUser(model))
                //判斷是否有次使用者
                {
                    return RedirectToLocal(returnUrl);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Login", "User");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(UserModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (bll.Add(model))//增加用戶
                {
                    return RedirectToAction("Login", new { });
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
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}