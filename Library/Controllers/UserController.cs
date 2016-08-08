using LibraryBLL;
using LibraryModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            UserBLL bll = new UserBLL();
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (bll.IsUser(model))//判斷是否有次使用者
                {
                    return RedirectToAction("library", "book", new { });
                }
            }
            return View();
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
                    return RedirectToAction("Login");
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