﻿using Library.Authorize;
using LibraryBLL;
using LibraryBLL.Home;
using LibraryCommon;
using LibraryModel;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BookController : Controller
    {
        private string ImagePath = ConfigurationManager.AppSettings["ImgaePath"];
        public BookController() {
            ddlBind();            
        }
        [HttpGet]

        public ActionResult AddBook()
        {
            return View();
        }

        /// <summary>
        /// 新增一本書
        /// </summary>
        /// <param name="files">頁面上的files Tag</param>
        /// <param name="model">回傳空的model代表 全部查詢</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddBook(IEnumerable<HttpPostedFileBase> files,
            [System.Web.Http.FromBody]Library_Book model)
        {
            if (ModelState.IsValid)
            {
                UploadFileHelper upload = new UploadFileHelper(files, Server.MapPath(ImagePath));
                upload.SaveImage();
                ImageBLL imageBll = new ImageBLL(Server.MapPath(ImagePath));
                BookBLL bll = new BookBLL();
                model.create_time = DateTime.Now;
                int bookId = bll.Add(model);
                model.Image = upload.BookAddImagePath(bookId);
                imageBll.AddImage(model);
                return View("Library", Init(1, new BookSearch_ViewModel()));
            }
            return View();
        }

        /// <summary>
        /// 刪除的控制器
        /// </summary>
        /// <param name="id">傳入Book的Id</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            BookBLL bll = new BookBLL();
            Library_Book model = new Library_Book() { id = id };
            bll.Delete(model);
            return View("Library", Init(1, new BookSearch_ViewModel()));
        }

        [HttpPost]
        public ActionResult EditBook(IEnumerable<HttpPostedFileBase> files,
            [System.Web.Http.FromBody]BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                UploadFileHelper upload = new UploadFileHelper(files, Server.MapPath(ImagePath));
                ddlBind();
                BookBLL bll = new BookBLL();
                upload.SaveImage();
                model.ImagePath = upload._FilesName;
                bll.Edit(model);
                return RedirectToAction("Library");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            BookBLL bll = new BookBLL();
            BookViewModel model = bll.GetBookModelById(id);

            ViewData["BookLanguage"] = DropDownListGenerator
                ("BookLanguage", "language", model.BookLanguage);
            ViewData["BookType"] = DropDownListGenerator
                ("BookType", "booktype", model.BookType);
            return View(model);
        }

        /// <summary>
        /// Library.cshtml的程式 顯示清單
        /// </summary>
        /// <param name="page">頁面</param>
        /// <returns></returns>
        public ActionResult Library([System.Web.Http.FromBody] BookSearch_ViewModel conditionModel, string page = "1")
        {
            IPagedList<Library_Book> model = Init(int.Parse(page), conditionModel);
            return View(model);
        }

        /// <summary>
        /// Bind下拉式選單
        /// </summary>
        private void ddlBind()
        {
            string Language = null;
            string BookType = null;
            string bookName = null;
            if (Request!=null)
            {
                Language = Request["BookLanguage"];
                BookType = Request["BookType"];
                bookName = Request["bookName"];
            }
            /*===Bind下拉式選單 begin===*/
            ViewData["BookLanguage"] = DropDownListGenerator
                ("BookLanguage", "language", Language);
            ViewData["BookType"] = DropDownListGenerator
                ("BookType", "booktype", BookType);
            ViewData["Serchvalue"] = bookName;
            /*===Bind下拉式選單 end===*/
        }

        /// <summary>
        /// 將資訊填充到BookSearch_ViewModel方便做查詢
        /// </summary>
        /// <returns></returns>
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
        /// <param name="defalutSelect">預設選項(沒選為null)</param>
        /// <returns></returns>
        private string DropDownListGenerator(string TagId,
            string parameterType,
            string defalutSelect = null)
        {
            BookBLL bll = new BookBLL();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<Parameter> paras = bll.GetParameterList();
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
                                       defalutSelect,
                                       true,
                                      "請選擇"
                                    );
        }

        /// <summary>
        /// 進入Library首頁
        /// </summary>
        /// <param name="page">頁碼</param>
        /// <param name="model">bookModel</param>
        /// <returns></returns>
        private IPagedList<Library_Book> Init(int page, BookSearch_ViewModel model)
        {
            BookBLL bll = new BookBLL();
            ImageBLL ImageBll = new ImageBLL("/LibraryImgae/");
            List<Library_Book> bookList = bll.GetList(model);
            return bookList.
                OrderBy(x => x.create_time).
                Select(x => new Library_Book()
                {
                    id = x.id,
                    summary = x.summary,
                    BookLanguage = x.BookLanguage,
                    bookName = x.bookName,
                    BookType = x.BookType,
                    create_time = x.create_time,
                    Image = ImageBll.GetImageList(x)
                }).ToPagedList(page, 12);
        }
    }
}