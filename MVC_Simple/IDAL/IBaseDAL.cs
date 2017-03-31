using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseDAL<T> 
        where T:class,new()
    {
        bool Insert(T model);
        void Update(T model);
        void Delete(T model);
        IEnumerable<T> GetListBy(Func<T, bool> predicate);       
    }
}
