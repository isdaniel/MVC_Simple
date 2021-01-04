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
            string sql = "SELECT * FROM dbo.ParameterSetting";

            var dapperContext = GetDapperContext(sql, false);

            return dapperContext.Query<Parameter>().Where(predicate);
        }
    }
}