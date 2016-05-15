using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.DAL
{
    public interface IDAL<T>
    {
        List<T> GetList();
        void Modify(T t);
        void Add(T t);
        void Delete(T t);
    }
}
