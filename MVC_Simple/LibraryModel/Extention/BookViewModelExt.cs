using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public partial class BookViewModel
    {
        public BookModel ToBookModel() {
            return new BookModel()
            {
                BookLanguage = this.BookLanguage,
                BookName = this.bookName,
                BookType = this.BookType,
                summary = this.summary,
                id = this.id
            };
        }
    }
}
