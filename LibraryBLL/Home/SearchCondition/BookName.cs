using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Home.SearchCondition
{
    public class BookName : ISearchContition
    {
        public void condition(SearchConcrete entity)
        {
            if (!String.IsNullOrEmpty(entity._Entity.bookName))
            {
                entity.sb.AppendLine("and bookName like @bookName");
            }
            entity.SetCondition(new BookType());
            entity.Next();
        }
    }
}