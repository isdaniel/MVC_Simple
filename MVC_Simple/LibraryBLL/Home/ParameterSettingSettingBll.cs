using LibraryModel;
using System;
using System.Collections.Generic;
using IDAL;
using LibraryDAL;

namespace LibraryBLL
{
    public class ParameterSettingSettingBll:IBLL.IParameterSettingBLL
    {
        readonly IParameterSettingDAL _parameterSettingDal = new ParameterSettingDAL();
        public IEnumerable<Parameter> GetListBy(Func<Parameter, bool> predicate) {
            return _parameterSettingDal.GetListBy(predicate);
        }
    }
}
