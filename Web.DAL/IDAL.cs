using System.Collections.Generic;
using System.Data;

namespace MyWeb.DAL
{
    public interface IDAL<T>
    {
        void Add(T t);

        void Delete(int i);

        List<T> GetList(string Sql, params IDataParameter[] parameters);

        void Modify(T t);
    }
}