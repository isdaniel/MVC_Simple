using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL
{
    public class ParameterBLL:IBLL.IParameterBLL
    {
        private IDAL.IDALWarehouse dal = new WarehouseDAL.DALWarehouse();
        public IEnumerable<Parameter> GetListBy(Func<Parameter, bool> predicate) {
            return dal.Parameter.GetListBy(predicate);
        }
    }
}
