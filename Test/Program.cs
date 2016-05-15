using MyWeb.BLL;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.DAL;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert();
            //Edit();
            Console.ReadKey();
        }
        static void BookTest()
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
        static void Insert()
        {
            BookModel model = new BookModel();
            model.summary = "test";
            BookUtility u = new BookUtility();
            u.Add(model);
        }
        static void Edit() {
            BookUtility u = new BookUtility();
            BookModel model = new BookModel();
            model.summary = "test";
            model.test_time = DateTime.Now.ToString("yyyy/MM/dd");
            model.BookLanguage = "Chinese";
            model.BookType = "information";
            model.id = "246";
            u.Edit(model);
        }
    }
}
