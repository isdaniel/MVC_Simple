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
            if (!String.IsNullOrEmpty(entity._Entity.BookName))
            {
                entity.sb.AppendLine("and BookName like @BookName");
            }
            entity.SetCondition(new BookType());
            entity.Next();
        }
    }
}