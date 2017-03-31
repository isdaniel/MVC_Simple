using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IParameterBLL
    {
        IEnumerable<Parameter> GetListBy(Func<Parameter, bool> predicate);
    }
}
