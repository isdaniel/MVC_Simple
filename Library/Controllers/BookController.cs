using LibraryBLL;
using LibraryBLL.Home;
using LibraryCommon;
using LibraryModel;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        /// <summary>
        /// Library.cshtml的程式 顯示清單
        /// </summary>
        /// <param name="page">頁面</param>
        /// <returns></returns>
        public ActionResult Library(string page = "1")
        {
            BookBLL bll = new BookBLL();
            ImageBLL ImageBll = new ImageBLL();
            List<BookModel> bookList = bll.GetList(ddlInfo());
            var model = bookList.
                OrderBy(x => x.create_time).
                Select(x => new BookModel()
                {
                    id = x.id,
                    summary = x.summary,
                    BookLanguage = x.BookLanguage,
                    bookName = x.bookName,
                    BookType = x.BookType,
                    create_time = x.create_time,
                    Image = ImageBll.GetImageList(x)
                }).
                ToPagedList(int.Parse(page), 12);
            /*===Bind下拉式選單 begin===*/
            ViewData["BookLanguage"] = DropDownListGenerator
                ("BookLanguage", "language");
            ViewData["BookType"] = DropDownListGenerator
                ("BookType", "booktype");
            /*===Bind下拉式選單 end===*/
            return View(model);
        }

        private BookSearch_ViewModel ddlInfo()
        {
            BookSearch_ViewModel viewmodel = new BookSearch_ViewModel();
            viewmodel.BookType = (string)Request["BookType"];
            viewmodel.bookName = '%' + (string)Request["bookName"] + '%';
            viewmodel.BookLanguage = (string)Request["BookLanguage"];
            return viewmodel;
        }

        /// <summary>
        /// 將參數綁到參數中
        /// </summary>
        /// <param name="TagId">Html下拉選單標籤ID</param>
        /// <param name="parameterType">哪個參數</param>
        /// <returns></returns>
        private string DropDownListGenerator(string TagId, string parameterType)
        {
            BookBLL bll = new BookBLL();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<ParameterModel> paras = bll.GetParameterList();
            var model = from i in paras
                        where i.parametertype == parameterType
                        select i;
            foreach (var item in model)
            {
                dict.Add(item.chinese, item.English);
            }
            return DropDownListHelper.GetDropdownList
                                    (
                                       TagId,
                                       dict,
                                       new { id = TagId },
                                       null,
                                       true,
                                      "請選擇"
                                    );
        }
    }
}