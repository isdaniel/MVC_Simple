using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryController
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult ErrorPage()
        {

            return View();
        }
    }
}