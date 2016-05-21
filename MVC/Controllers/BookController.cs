using MyWeb.BLL;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private BookBLL bll = new BookBLL();

        private BookModel BookMoudle = new BookModel();

        [HttpGet]
        public ActionResult AddBook()
        {
            Bind_DDL();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(FormCollection form)
        {
            BookModel model = new BookModel()
            {
                summary = form["summary"],
                BookLanguage = form["Language"],
                BookType = form["BookType"],
                test_time = DateTime.Now.ToString("yyyy/MM/dd"),
                bookName = form["BookName"]
            };
            bll.Add(model);
            return RedirectToAction("Index", "Book", new object { });
        }

        public ActionResult Delete(int id)
        {
            bll.Delete(id);
            return RedirectToAction("Index", "Book", new object { });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Bind_DDL();
            return View(bll.Edit_Model(id));
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            BookModel model = new BookModel()
            {
                id = form["id"],
                test_time = DateTime.Now.ToString("yyyy/MM/dd"),
                summary = form["summary"],
                BookLanguage = form["language"],
                BookType = form["bookType"],
                bookName = form["bookName"]
            };
            bll.Edit(model);
            return RedirectToAction("Index", "Book", new object { });
        }

        public ActionResult Index(string page)
        {
            page = page == null ? "1" : page;
            BookBLL bll = new BookBLL();
            int _Page = int.Parse(page);
            ViewData["page"] = page;
            List<BookModel> list = GetModel();
            Bind_DDL();
            return View(new MyViewModel()
            {
                books = list.Skip((_Page - 1) * 10).Take(10),
                PageTotal = list.Count
            });
        }

        private void Bind_DDL()
        {
            ParameterBLL paramterBLL = new ParameterBLL();
            ViewData["BookType"] = DropDown.SetDropDownList(
                paramterBLL.Get_Parameter("booktype"));
            ViewData["Language"] = DropDown.SetDropDownList(
                paramterBLL.Get_Parameter("language"));
        }

        private List<BookModel> GetModel()
        {
            string Language = Request["Language"] == null ? "" :
               Request["Language"].ToString();
            string BookType = Request["BookType"] == null ? "" :
                Request["BookType"].ToString();
            PagerMode model = new PagerMode()
            {
                Language = Language,
                Type = BookType
            };
            ViewData["Parameters"] = model;
            List<BookModel> list = new List<BookModel>();
            if (ViewData["DataList"] == null)
            {
                list = bll.GetList(model);
                ViewData["DataList"] = list;
            }
            else
            {
                list = (List<BookModel>)ViewData["DataList"];
            }
            return list;
        }

        public class MyViewModel
        {
            public IEnumerable<BookModel> books { get; set; }
            public int PageTotal { get; set; }
        }
    }

    internal static class DropDown
    {
        public static List<SelectListItem> SetDropDownList
            (List<ParamterModel> list)
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            foreach (ParamterModel item in list)
            {
                SelectListItem selector = new SelectListItem();
                selector.Text = item.ParameterContent;
                selector.Value = item.ParameterCode;
                selectItems.Add(selector);
            }
            return selectItems;
        }
    }
}