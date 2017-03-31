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
        bool Insert(Library_BookImgae model);

        void Update(Library_BookImgae model);

        void Delete(Library_BookImgae model);

        IEnumerable<Library_BookImgae> GetListBy(Func<Library_BookImgae, bool> predicate);
    }
}
