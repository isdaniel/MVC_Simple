using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class BookSearchViewModel
    {
        /// <summary>
        /// 書的語言
        /// </summary>
        public string BookLanguage { get; set; }

        /// <summary>
        /// 書名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 書的類別
        /// </summary>
        public string BookType { get; set; }
    }
}