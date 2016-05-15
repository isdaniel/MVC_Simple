using MyWeb.BLL;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MVC.Controllers
{
    static class DropDown {
        public static List<SelectListItem> SetDropDownList
            (List<ParamterModel> list)
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            foreach (ParamterModel item in list) {
                SelectListItem selector = new SelectListItem();
                selector.Text = item.ParameterContent;
                selector.Value = item.ParameterCode;
                selectItems.Add(selector);
            }
            return selectItems;
        }
    }
    public class BookController : Controller
    {
        private void Bind_DDL()
        {
            ParameterBLL paramterBLL = new ParameterBLL();
            ViewData["booktype"] = DropDown.SetDropDownList(
                paramterBLL.Get_Parameter("booktype"));
            ViewData["language"] = DropDown.SetDropDownList(
                paramterBLL.Get_Parameter("language"));
        }
        BookBLL bll = new BookBLL();
        BookModel BookMoudle = new BookModel();
        public class MyViewModel
        {
            public int PageTotal { get; set; }
            public IEnumerable<BookModel> books { get; set; }
        }
        public ActionResult Index(string page)
        {  
            if (page == null)
                page = "1";
            BookBLL bll = new BookBLL();
            string Language = Request["Language"] == null ? "" :
                Request["Language"].ToString();
            string BookType = Request["BookType"] == null ? "" :
                Request["BookType"].ToString();
            int _Page=int.Parse(page);
            PagerMode model=new PagerMode(){
                 Language=Language,
                 Type=BookType
            };
            ViewData["page" ] = page;
            List<BookModel> list=bll.GetList(model);
            Bind_DDL();
            return View(new MyViewModel() { 
                books = list.Skip((_Page - 1) * 10).Take(10), 
                PageTotal = list.Count });
        }
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
    }
}
