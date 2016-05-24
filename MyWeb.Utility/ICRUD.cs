using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyWeb.Utility
{
    public interface ICRUD<T>
    {
        void Add(T t);

        void Delete(int id);

        List<T> GetList(string SQLText, params SqlParameter[] parameters);

        void Modify(T t);
    }
}