using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Home.SearchCondition
{
    public class BookType : ISearchContition
    {
        public void condition(SearchConcrete entity)
        {
            if (!String.IsNullOrEmpty(entity._Entity.BookType))
            {
                entity.sb.AppendLine("and BookType=@BookType");
            }
        }
    }
}