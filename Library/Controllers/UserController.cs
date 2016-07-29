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
            if (bll.IsUserExist(model))
            {
                return RedirectToAction("Index", "Book", new { });
            }
            else
            {
                return View();
            }
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
            string message = "";
            if (bll.Add(model))
            {
                return RedirectToAction("Login");
            }
            else
            {
                message = "帳戶已存在";
                ViewBag.message = message;
                return View();
            }
        }
    }
}