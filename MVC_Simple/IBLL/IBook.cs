using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBook
    {
        /// <summary>
        /// 刪除書 
        /// </summary>
        /// <param name="model"></param>
        void Delete(BookModel model);


        /// <summary>
        /// 取得所有書的資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerable<BookModel> GetListBy (Func<BookModel, bool> whereLambda);

        int InsertGetId(BookModel model);
    }
}
