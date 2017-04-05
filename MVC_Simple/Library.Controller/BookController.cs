using LibraryCommon;
using LibraryModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryController
{
    public partial class BookController : ControllerBase
    {

        public BookController()
        {
            SetDropDown();
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
        public ActionResult AddBook(IEnumerable<HttpPostedFileBase> files, [System.Web.Http.FromBody]Library_Book model)
        {
            if (ModelState.IsValid)
            {
                UploadFileHelper upload = new UploadFileHelper
                (files, _imagePath);
                upload.SaveImage();
                int bookId = BookRepositroy.InsertGetId(model);
                var Images = upload.BookAddImagePath(bookId);
                foreach (var item in Images)
                {
                    BookImageRepositroy.Insert(item);
                }
                return View("Library", GetPage(1));
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
            Library_Book model = new Library_Book() { id = id };
            BookRepositroy.Delete(model);
            return View("Library", GetPage(1));
        }

        [HttpPost]
        public ActionResult EditBook(IEnumerable<HttpPostedFileBase> files,
            [System.Web.Http.FromBody]BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                UploadFileHelper upload = new UploadFileHelper
                (files, _imagePath);
                SetDropDown();
                upload.SaveImage();
                var Images = upload.BookAddImagePath(model.id);
                foreach (var item in Images)
                {
                    BookImageRepositroy.Insert(item);
                }
                return RedirectToAction("Library");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var model = BookRepositroy.
                GetListBy(u => u.id == id).Select(o=> {
                    return new BookViewModel()
                    {
                        BookLanguage=o.BookLanguage,
                        bookName=o.bookName,
                        BookType=o.BookType,
                        summary=o.summary,
                        ImagePath=GetImageByBookId(o.id)                        
                    };
                }).FirstOrDefault();
            SetDropDown();
            return View(model);
        }

        /// <summary>
        /// Library.cshtml的程式 顯示清單
        /// </summary>
        /// <param name="page">頁面</param>
        /// <returns></returns>
        public ActionResult Library([System.Web.Http.FromBody] BookSearch_ViewModel conditionModel, string page = "1")
        {
            SetDropDown();
            return View(GetPage(int.Parse(page), conditionModel));
        }
  
    }
}