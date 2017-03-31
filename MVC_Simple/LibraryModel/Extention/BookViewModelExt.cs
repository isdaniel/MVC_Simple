using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public partial class BookViewModel
    {
        public Library_Book ToBookModel() {
            return new Library_Book()
            {
                BookLanguage = this.BookLanguage,
                bookName = this.bookName,
                BookType = this.BookType,
                summary = this.summary,
                id = this.id
            };
        }
    }
}
