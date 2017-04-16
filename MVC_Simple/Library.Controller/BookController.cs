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
                UploadManage manage = new UploadManage(files);
                manage.SetNext(new FileFilter())
                      .SetNext(new FileSize())
                      .SetNext(new Uploader());
                manage.Execute();
                int bookId = BookRepositroy.InsertGetId(model);
                InsertImage(files, bookId);
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
                //UploadMananger upload = new UploadMananger(FileType.Image);
                //upload.SaveImage(files);
                UploadManage manage = new UploadManage(files);
                manage.SetNext(new FileSize())
                      .SetNext(new FileFilter())
                      .SetNext(new Uploader());
                manage.Execute();
                InsertImage(files, model.id);
                SetDropDown();
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

        /// <summary>
        /// 儲存圖片
        /// </summary>
        /// <param name="files"></param>
        /// <param name="BookId"></param>
        private void InsertImage
            (IEnumerable<HttpPostedFileBase> files,int BookId)
        {
            foreach (var file in files)
            {
                if (file!=null)
                {
                    BookImageRepositroy.Insert(new Library_BookImgae()
                    {
                        BookId = BookId,
                        Image_Path = file.FileName
                    });
                }
            }
        }
        /// <summary>
        /// 創建不重複檔名
        /// </summary>
        /// <returns></returns>
        private string CreatePrefixName(string name)
        {
            return 
                Guid.NewGuid().ToString() +
                DateTime.Now.Month.ToString()+
                name;
        }
    }
}