﻿using LibraryCommon;
using LibraryModel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using WarehouseBLL;

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
            
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            if (AuthorizeContext.Current.
                Login(model.ToUserModel(), ModelState.IsValid))
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
            
            if (ModelState.IsValid)//是否符合資料驗證(後端驗證)
            {
                if (AuthorizeContext.Current.InsertAccount(
                    model.ToUserModel()))//增加用戶
                {
                    return RedirectToAction("Library", "Book");
                }
                ViewBag.message = "帳戶已存在";
            }
            return View();
        }
    }
}