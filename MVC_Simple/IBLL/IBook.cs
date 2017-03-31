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
        /// 新增一本書
        /// </summary>
        /// <param name="model"></param>
        bool Insert(Library_Book model);

        /// <summary>
        /// 刪除書 
        /// </summary>
        /// <param name="model"></param>
        void Delete(Library_Book model);

        /// <summary>
        /// 修改書的資訊
        /// </summary>
        /// <param name="model"></param>
        void Update(Library_Book model);
  

        /// <summary>
        /// 取得所有書的資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerable<Library_Book> GetListBy (Func<Library_Book, bool> whereLambda);

        int InsertGetId(Library_Book model);
    }
}
