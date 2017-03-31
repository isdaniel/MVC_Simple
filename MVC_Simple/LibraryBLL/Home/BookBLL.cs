using IBLL;
using IDAL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarehouseDAL;

namespace LibraryBLL
{
    public class BookBLL : IBook
    {
        private IDALWarehouse dal = new DALWarehouse();

        public void Delete(Library_Book model)
        {
            dal.Book.Delete(model);
        }

        public IEnumerable<Library_Book> GetListBy(Func<Library_Book,bool> whereLambda)
        {
            return dal.Book.GetListBy(whereLambda);
        }


        public bool Insert(Library_Book model)
        {
           return dal.Book.Insert(model);
        }
        public int InsertGetId(Library_Book model) {
            return dal.Book.InsertGetId(model);
        }
        public void Update(Library_Book model)
        {
            dal.Book.Update(model);
        }
        #region MyRegion
        ///// <summary>
        ///// 新增一本書
        ///// </summary>
        ///// <param name="model"></param>
        //public int Insert(Library_Book model)
        //{
        //    return dal.Add(model);
        //}

        ///// <summary>
        ///// 刪除書 
        ///// </summary>
        ///// <param name="model"></param>
        //public void Delete(Library_Book model)
        //{
        //    using (BookConcrete concrete = new BookConcrete())
        //    {
        //        concrete.Entry(model).State = EntityState.Deleted;
        //        concrete.Book.Attach(model);
        //        concrete.Book.Remove(model);//刪除書本
        //        var itemsToDelete = concrete.Library_BookImgae
        //            .Where(u => u.BookId == model.id);//找尋書下的圖片
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
        //        Library_Book book = new Library_Book()
        //        {
        //            id = model.id,
        //            BookLanguage = model.BookLanguage,
        //            bookName = model.bookName,
        //            summary = model.summary,
        //            BookType = model.BookType
        //        };
        //        foreach (var file in model.ImagePath)
        //        {
        //            Library_BookImgae image = new Library_BookImgae()
        //            {
        //                BookId = model.id,
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
        ///// <param name="id">book的編號</param>
        ///// <returns></returns>
        //public BookViewModel GetBookModelById(int id)
        //{
        //    using (BookConcrete concrete = new BookConcrete())
        //    {
        //        /*===將書的資訊填入BookViewModel中 begin===*/
        //        BookViewModel model = concrete.Book.Where(u => u.id == id).Select(u => new BookViewModel
        //        {
        //            BookLanguage = u.BookLanguage,
        //            BookType = u.BookType,
        //            id = u.id,
        //            summary = u.summary,
        //            bookName = u.bookName,
        //            create_time = u.create_time
        //        }).FirstOrDefault();
        //        /*===將書的資訊填入BookViewModel中 end===*/
        //        /*===將圖片的資訊塞入BookViewModel中 begin===*/
        //        var IamgeList = (from i in concrete.Library_BookImgae
        //                         where i.BookId == id
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
        //public List<Library_Book> GetList(BookSearch_ViewModel model)
        //{
        //    SearchConcrete concrete = new SearchConcrete(model);
        //    StringBuilder sb = new StringBuilder();
        //    concrete.SetCondition(new BookLanguage());
        //    string SqlString = concrete.Next();
        //    sb.AppendLine("select * from Library_Book");
        //    sb.AppendLine("where 1=1");
        //    sb.AppendLine(SqlString);
        //    return BookListViewModel(dal.GetList(sb.ToString(), model));
        //}

        ///// <summary>
        ///// 取得所有參數
        ///// </summary>
        ///// <returns></returns>
        //public List<Parameter> GetParameterList()
        //{
        //    ParameterDal paraDal = ParameterDal.GetInstace();
        //    return paraDal.GetAllParameter();
        //}

        ///// <summary>
        ///// 將書本資訊查詢
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //private List<Library_Book> BookListViewModel(List<Library_Book> model)
        //{
        //    ParameterDal paraDal = ParameterDal.GetInstace();
        //    List<Parameter> parameters = paraDal.GetAllParameter();
        //    var ViewModel = from item in model
        //                    join language in parameters
        //                    on item.BookLanguage equals language.English
        //                    join booktype in parameters
        //                    on item.BookType equals booktype.English
        //                    select new Library_Book
        //                    {
        //                        BookLanguage = booktype.chinese,
        //                        BookType = language.chinese,
        //                        id = item.id,
        //                        summary = item.summary,
        //                        bookName = item.bookName,
        //                        create_time = item.create_time
        //                    };
        //    return ViewModel.ToList();
        //} 
        #endregion

    }
}