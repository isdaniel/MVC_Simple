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

namespace LibraryController
{
    public class BookController : Controller
    {
        public BookController()
        {
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
        public ActionResult AddBook(IEnumerable<HttpPostedFileBase> files, [System.Web.Http.FromBody]Library_Book model)
        {
            if (ModelState.IsValid)
            {
                UploadFileHelper upload = new UploadFileHelper
                (files, LibraryContext.Current.ImagePath);
                IBLL.IBook Book = LibraryContext.Current.Warehouse.Book;
                IBLL.IBookImage BookImage =
                    LibraryContext.Current.Warehouse.BookImage;
                upload.SaveImage();
                int bookId = Book.InsertGetId(model);
                var Images = upload.BookAddImagePath(bookId);
                foreach (var item in Images)
                {
                    BookImage.Insert(item);
                }
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
                UploadFileHelper upload = new UploadFileHelper
                (files, LibraryContext.Current.ImagePath);
                ddlBind();
                upload.SaveImage();
                model.ImagePath = upload._FilesName;
                LibraryContext.Current.Warehouse.Book.Update(model.ToBookModel());
                return RedirectToAction("Library");
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var model = LibraryContext.Current.Warehouse.Book.
                GetListBy(u => u.id == id).FirstOrDefault();
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
            IPagedList<BookViewModel> model =
                Init(int.Parse(page), conditionModel);
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
            if (Request != null)
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
        /// 將參數綁到參數中
        /// </summary>
        /// <param name="TagId">Html下拉選單標籤ID</param>
        /// <param name="parameterType">哪個參數</param>
        /// <param name="defalutSelect">預設選項(沒選為null)</param>
        /// <returns></returns>
        private string DropDownListGenerator(
            string TagId,
            string parameterType,
            string defalutSelect = null)
        {
            var Parameter = LibraryContext.Current.Warehouse.Parameter;
            Dictionary<string, string> dict =
                new Dictionary<string, string>();
            var paras = Parameter.GetListBy(u => u.parametertype == parameterType).ToList();
            foreach (var item in paras)
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
        private IPagedList<BookViewModel> Init
            (int page, BookSearch_ViewModel model)
        {
            List<string> imagePaths = new List<string>();
            var BookList = LibraryContext.Current.Warehouse.Book.GetListBy(u =>
              !string.IsNullOrEmpty(model.BookLanguage) ?
              u.BookLanguage == model.BookLanguage : true &&
             !string.IsNullOrEmpty(model.bookName) ?
             u.bookName == model.bookName : true &&
              !string.IsNullOrEmpty(model.BookType) ?
              u.BookType == model.BookType : true);

            //!string.IsNullOrEmpty(userAccText.Text) ? userAccText.Text == a.dev_user_account : true

            return BookList.
                OrderBy(x => x.create_time).
                Select(x => new BookViewModel()
                {
                    id = x.id,
                    summary = x.summary,
                    BookLanguage = x.BookLanguage,
                    bookName = x.bookName,
                    BookType = x.BookType,
                    create_time = x.create_time
                }).ToPagedList(page, 12);
        }
    }
}