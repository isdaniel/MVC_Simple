using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IBLLWarehouse
    {
        IUser User { get; }
        IBook Book { get; }
        IBookImage BookImage { get; }
        IParameterBLL Parameter { get; }
    }
}
