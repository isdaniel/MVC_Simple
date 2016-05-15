using MyWeb.BLL;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
        public ActionResult Index(UserModel u)
        {
            //string UserName =u.user_txt;
            //string PassWord = u.password_txt;
            //UserBLL bll = new UserBLL();
            //if (bll.IsValidaion(PassWord, UserName))
            //{
            //    return RedirectToAction("Index", "Book", new { });
            //}
            //else {
            //    ViewBag.visable = "Yes";
            //    return View();
            //}
            return View();
        }
    }
}
