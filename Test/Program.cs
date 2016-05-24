using MyWeb.BLL;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.DAL;

namespace Test
{
    public class Program
    {
        private static void BookTest()
        {
            BookBLL bll = new BookBLL();
            PagerMode model = new PagerMode();
            model.Language = null;
            model.Type = null;
            var pageCnt = 2;
            var pageRows = 10;
            List<BookModel> list = bll.GetList(model);
            var listss = list.OrderBy(o => o.test_time).Skip((pageCnt - 1) * 10).Take(10);
            foreach (var item in listss)
            {
                Console.WriteLine(item.summary);
            }
        }

        private static void Edit()
        {
            BookUtility u = new BookUtility();
            BookModel model = new BookModel();
            model.summary = "test";
            model.test_time = DateTime.Now.ToString("yyyy/MM/dd");
            model.BookLanguage = "Chinese";
            model.BookType = "information";
            model.id = "246";
            u.Edit(model);
        }

        private static void Insert()
        {
            BookModel model = new BookModel();
            model.summary = "test";
            BookUtility u = new BookUtility();
            u.Add(model);
        }

        private static void Main(string[] args)
        {
            //TestDAL dal = new TestDAL();
            //BookModel model = new BookModel();
            //model.summary = "test";
            ////dal.GetList("select * from test");
            //dal.Add(model);
            //Insert();
            //Edit();
            Console.ReadKey();
        }
    }

    //public class TestDAL : DALUtility<BookModel>
    //{
    //    protected override string TableName()
    //    {
    //        return "test";
    //    }
    //}
}