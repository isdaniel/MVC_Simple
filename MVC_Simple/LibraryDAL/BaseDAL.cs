using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL
{
    public abstract class BaseDAL<T> : IDAL.IBaseDAL<T>
         where T : class, new()
    {
        protected DbContext _Dbcontext = new EFConcrete();

        public void Delete(T model)
        {
            _Dbcontext.Entry<T>(model).State = EntityState.Deleted;
            _Dbcontext.SaveChanges();
        }

        public IEnumerable<T> GetListBy(Func<T, bool> predicate)
        {
            return _Dbcontext.Set<T>().Where(predicate);
        }

        public bool Insert(T model)
        {
            
            _Dbcontext.Entry<T>(model).State = EntityState.Added;
            return _Dbcontext.SaveChanges()>0;
        }

        public virtual void Update(T model)
        {
            _Dbcontext.Entry<T>(model).State = EntityState.Modified;
            _Dbcontext.SaveChanges();
        }
    }
}
