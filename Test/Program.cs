using LibraryBLL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BookBLL bll = new BookBLL();
            BookSearch_ViewModel model = new BookSearch_ViewModel();
            model.BookLanguage = "chinese";
            model.BookType = "art";
            bll.GetList(model);
            Console.ReadKey();
        }
    }
}