using IBLL;
using IDAL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryDAL;


namespace LibraryBLL
{
    public class BookBLL : IBook
    {
       IBookDAL _bookDal = new BookDAL();

        public void Delete(BookModel model)
        {
            _bookDal.Delete(model);
        }

        public IEnumerable<BookModel> GetListBy(Func<BookModel,bool> whereLambda)
        {
            return _bookDal.GetListBy(whereLambda);
        }


        public int InsertGetId(BookModel model) {
            return _bookDal.InsertGetId(model);
        }

        #region MyRegion
        ///// <summary>
        ///// 新增一本書
        ///// </summary>
        ///// <param name="model"></param>
        //public int InsertUserInfo(BookModel model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 刪除書 
        ///// </summary>
        ///// <param name="model"></param>
        //public void Delete(BookModel model)
        //{
        //    using (BookConcrete concrete = new BookConcrete())
        //    {
        //        concrete.Entry(model).State = EntityState.Deleted;
        //        concrete.Book.Attach(model);
        //        concrete.Book.Remove(model);//刪除書本
        //        var itemsToDelete = concrete.BookImageModel
        //            .Where(u => u.BookId == model.ID);//找尋書下的圖片
        //        concrete.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 修改書的資訊
        ///// </summary>
        ///// <param name="model"></param>
        //public void Edit(BookViewModel model)
        //{
        //    using (BookConcrete concrete = new BookConcrete())
        //    {
        //        BookModel book = new BookModel()
        //        {
        //            ID = model.ID,
        //            BookLanguage = model.BookLanguage,
        //            BookName = model.BookName,
        //            summary = model.summary,
        //            BookType = model.BookType
        //        };
        //        foreach (var file in model.ImagePath)
        //        {
        //            BookImageModel image = new BookImageModel()
        //            {
        //                BookId = model.ID,
        //                Image_Path = file
        //            };
        //            concrete.Entry(image).State = EntityState.Added;
        //        }
        //        concrete.Entry(book).State = EntityState.Modified;
        //        concrete.SaveChanges();
        //    }
        //}

        ///// <summary>
        ///// 取得BookModel藉由編號
        ///// </summary>
        ///// <param name="ID">book的編號</param>
        ///// <returns></returns>
        //public BookViewModel GetBookModelById(int ID)
        //{
        //    using (BookConcrete concrete = new BookConcrete())
        //    {
        //        /*===將書的資訊填入BookViewModel中 begin===*/
        //        BookViewModel model = concrete.Book.Where(u => u.ID == ID).Select(u => new BookViewModel
        //        {
        //            BookLanguage = u.BookLanguage,
        //            BookType = u.BookType,
        //            ID = u.ID,
        //            summary = u.summary,
        //            BookName = u.BookName,
        //            CreateTime = u.CreateTime
        //        }).FirstOrDefault();
        //        /*===將書的資訊填入BookViewModel中 end===*/
        //        /*===將圖片的資訊塞入BookViewModel中 begin===*/
        //        var IamgeList = (from i in concrete.BookImageModel
        //                         where i.BookId == ID
        //                         select "/LibraryImgae/" + i.Image_Path).ToList();
        //        model.ImagePath = IamgeList;
        //        /*===將圖片的資訊塞入BookViewModel中 end===*/
        //        return model;
        //    }
        //}

        ///// <summary>
        ///// 取得所有書的資訊
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public List<BookModel> GetList(BookSearchViewModel model)
        //{
        //    SearchConcrete concrete = new SearchConcrete(model);
        //    StringBuilder sb = new StringBuilder();
        //    concrete.SetCondition(new BookLanguage());
        //    string SqlString = concrete.Next();
        //    sb.AppendLine("select * from BookModel");
        //    sb.AppendLine("where 1=1");
        //    sb.AppendLine(SqlString);
        //    return BookListViewModel(dal.GetList(sb.ToString(), model));
        //}

        ///// <summary>
        ///// 取得所有參數
        ///// </summary>
        ///// <returns></returns>
        //public List<ParameterSetting> GetParameterList()
        //{
        //    ParameterDal paraDal = ParameterDal.GetInstace();
        //    return paraDal.GetAllParameter();
        //}

        ///// <summary>
        ///// 將書本資訊查詢
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //private List<BookModel> BookListViewModel(List<BookModel> model)
        //{
        //    ParameterDal paraDal = ParameterDal.GetInstace();
        //    List<ParameterSetting> parameters = paraDal.GetAllParameter();
        //    var ViewModel = from item in model
        //                    join Language in parameters
        //                    on item.BookLanguage equals Language.English
        //                    join BookType in parameters
        //                    on item.BookType equals BookType.English
        //                    select new BookModel
        //                    {
        //                        BookLanguage = BookType.chinese,
        //                        BookType = Language.chinese,
        //                        ID = item.ID,
        //                        summary = item.summary,
        //                        BookName = item.BookName,
        //                        CreateTime = item.CreateTime
        //                    };
        //    return ViewModel.ToList();
        //} 
        #endregion

    }
}