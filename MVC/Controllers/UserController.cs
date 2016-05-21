using MyWeb.BLL;
using MyWeb.Common;
using MyWeb.Model;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            UserBLL bll = new UserBLL();
            if (bll.IsValidaion(model))
            {
                return RedirectToAction("Index", "Book", new { });
            }
            else
            {
                return View();
            }
        }
    }
}