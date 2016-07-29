using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Home.SearchCondition
{
    public class BookLanguage : ISearchContition
    {
        public void condition(SearchConcrete entity)
        {
            if (!String.IsNullOrEmpty(entity._Entity.BookLanguage))
            {
                entity.sb.AppendLine("and BookLanguage=@BookLanguage");
            }
            entity.SetCondition(new BookName());
            entity.Next();
        }
    }
}