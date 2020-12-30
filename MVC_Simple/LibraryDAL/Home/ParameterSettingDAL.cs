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
    public partial class ParameterSettingDAL : DapperBase,
        IParameterSettingDAL
    {
        public bool Insert(Parameter model)
        {
            throw new NotImplementedException();
        }

        public void Update(Parameter model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Parameter model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parameter> GetListBy(Func<Parameter, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}