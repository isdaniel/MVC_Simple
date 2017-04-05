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
        string _imagePath = ConfigHelper.AppSetting("ImgaePath");
        /// <summary>
        /// 書名的下拉選單
        /// </summary>
        public IEnumerable<SelectListItem> BookLanguage
        {
            get
            {
                return GetDropDown(eDropDown.language);
            }
        }
        /// <summary>
        /// 書類別的下拉選單
        /// </summary>
        public IEnumerable<SelectListItem> BookType
        {
            get
            {
                return GetDropDown(eDropDown.booktype);
            }
        }
        #region 取得下拉選單的資料 + GetDropDown(eDropDown parameterType)
        /// <summary>
        /// 取得下拉選單的資料
        /// </summary>
        /// <param name="parameterType">下拉選單的參數</param>
        /// <returns></returns>
        private IEnumerable<SelectListItem> GetDropDown
            (eDropDown parameterType)
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
                var paras = ParameterRepositroy.GetListBy
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
                    dropList, DateTimeOffset.Now.AddMinutes(30)
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
            return GetPage(page, new BookSearch_ViewModel());
        }

        /// <summary>
        /// 進入首頁顯示的頁面(有條件)
        /// </summary>
        /// <param name="page">頁碼</param>
        /// <param name="model">查詢條件的model</param>
        /// <returns></returns>
        private IPagedList<BookViewModel> GetPage
            (int page, BookSearch_ViewModel model)
        {
            List<string> imagePaths = new List<string>();

            var BookList = BookRepositroy.GetListBy(
                u =>
                !string.IsNullOrEmpty(model.BookLanguage) ?
                u.BookLanguage == model.BookLanguage : true &&
                !string.IsNullOrEmpty(model.bookName) ?
                u.bookName == model.bookName : true &&
                !string.IsNullOrEmpty(model.BookType) ?
                u.BookType == model.BookType : true);

            return BookList.
                OrderBy(x => x.create_time).
                Select(x => new BookViewModel()
                {
                    id = x.id,
                    summary = x.summary,
                    BookLanguage = x.BookLanguage,
                    bookName = x.bookName,
                    BookType = x.BookType,
                    create_time = x.create_time,
                    ImagePath= GetImageByBookId(x.id)
                }).ToPagedList(page, 12);
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
            var images=BookImageRepositroy.GetListBy(b => b.BookId == id);
            if (images.Count()>0)
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
