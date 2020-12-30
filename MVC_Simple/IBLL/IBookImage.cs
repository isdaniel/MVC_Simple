using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBookImage
    {
        bool Insert(BookImageModel model);

        IEnumerable<BookImageModel> GetListBy(Func<BookImageModel, bool> predicate);
    }
}
