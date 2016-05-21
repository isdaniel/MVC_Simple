using System.Collections.Generic;

namespace MyWeb.DAL
{
    public interface IDAL<T>
    {
        void Add(T t);

        void Delete(int i);

        List<T> GetList();

        void Modify(T t);
    }
}