using IBLL;
using IDAL;
using LibraryCommon;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using LibraryDAL;


namespace LibraryBLL
{
    public class BookImageBLL:IBookImage
    {
        IBookImageDAL _bookImageDal = new IBookmageDAL();
        public bool Insert(BookImageModel model)
        {
           return _bookImageDal.Insert(model);
        }

        public void Update(BookImageModel model)
        {
            _bookImageDal.Update(model);
        }

        public void Delete(BookImageModel model)
        {
            _bookImageDal.Delete(model);
        }

        public IEnumerable<BookImageModel> GetListBy(Func<BookImageModel, bool> predicate)
        {
            return _bookImageDal.GetListBy(predicate);
        }
    }
}