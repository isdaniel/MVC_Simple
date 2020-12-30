using LibraryCommon;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
namespace LibraryController
{
    public partial class BookController
    {
        /// <summary>
        /// 圖片儲存的路徑
        /// </summary>
        string _imagePath = ConfigHelper.ImagePath;
        /// <summary>
        /// 書名的下拉選單
        /// </summary>
        public IEnumerable<SelectListItem> BookLanguage
        {
            get
            {
                return GetDropDown(DropDownType.Language);
            }
        }
        /// <summary>
        /// 書類別的下拉選單
        /// </summary>
        public IEnumerable<SelectListItem> BookType
        {
            get
            {
                return GetDropDown(DropDownType.BookType);
            }
        }

        #region 取得下拉選單的資料 + GetDropDown(DropDownType parameterType)
        /// <summary>
        /// 取得下拉選單的資料
        /// </summary>
        /// <param name="parameterType">下拉選單的參數</param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetDropDown
            (DropDownType parameterType)
        {
            //要查詢之參數
            string paraString = parameterType.ToString();
            //取得記憶體中的資料
            List<SelectListItem> dropList =
                Cache[paraString] as List<SelectListItem>;
            //如果沒有創建一個新的
            if (dropList == null)
            {
                dropList = new List<SelectListItem>();
                var paras = ParameterSettingRepositroy.GetListBy
                (u => u.parametertype == paraString).ToList();
                paras.ForEach((p) =>
                {
                    dropList.Add(new SelectListItem()
                    {
                        Text = p.chinese,
                        Value = p.English
                    });
                });
                //將資料存入快取中方便下次取出
                Cache.Set(
                    paraString,
                    dropList, DateTimeOffset.Now.AddMinutes(10)
                    );
            }
            return dropList;
        }
        #endregion

        /// <summary>
        /// 進入首頁顯示的頁面(無條件)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private IPagedList<BookViewModel> GetPage(int page) {
            return GetPage(page, new BookSearchViewModel());
        }

        /// <summary>
        /// 進入首頁顯示的頁面(有條件)
        /// </summary>
        /// <param name="page">頁碼</param>
        /// <param name="model">查詢條件的model</param>
        /// <returns></returns>
        private IPagedList<BookViewModel> GetPage
            (int page, BookSearchViewModel model)
        {
            List<string> imagePaths = new List<string>();

            var BookList = GetBookList(model);

            return BookList.
                OrderBy(x => x.CreateTime).
                Select(x => new BookViewModel()
                {
                    id = x.id,
                    summary = x.summary,
                    BookLanguage = x.BookLanguage,
                    bookName = x.BookName,
                    BookType = x.BookType,
                    create_time = x.CreateTime,
                    ImagePath= GetImageByBookId(x.id)
                }).ToPagedList(page, 12);
        }
        /// <summary>
        /// 取得書本資訊
        /// </summary>
        /// <param name="model">條件</param>
        /// <returns></returns>
        private IEnumerable<BookModel> GetBookList(BookSearchViewModel model) {
            return BookRepositroy.GetListBy
                (u =>
                !string.IsNullOrEmpty(model.BookLanguage) ?
                u.BookLanguage == model.BookLanguage : !string.IsNullOrEmpty(model.BookName) ?
                u.BookName == model.BookName : string.IsNullOrEmpty(model.BookType) || u.BookType == model.BookType);
        }
        /// <summary>
        /// 設置頁面上的下拉選單
        /// </summary>
        private void SetDropDown()
        {
            ViewData["BookLanguage"] = BookLanguage;
            ViewData["BookType"] = BookType;
        }
        /// <summary>
        /// 取得圖片路徑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<string> GetImageByBookId(int id) {
            List<string> imagePaths = new List<string>();
            string no_pic = _imagePath + "No_Pic.gif";
            var images = BookImageRepositroy.GetListBy(b => b.BookId == id);
            if (images.Any())
            {
                foreach (var image in images)
                {
                    imagePaths.Add(_imagePath + image.Image_Path);
                }
            }
            else
            {
                imagePaths.Add(no_pic);
            }
            return imagePaths;
        }   
    }
}
