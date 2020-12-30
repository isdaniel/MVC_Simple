using Dapper;
using IDAL;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public partial class IBookmageDAL: DapperBase, IBookImageDAL
    {
        public bool Insert(BookImageModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(BookImageModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(BookImageModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookImageModel> GetListBy(Func<BookImageModel, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}