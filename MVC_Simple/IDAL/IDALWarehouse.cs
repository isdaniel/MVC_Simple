using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface IDALWarehouse
    {
        IUserDAL User {get;}
        IBookDAL Book { get; }
        IBookImgaeDAL BookImage { get; }
        IParameterDAL Parameter { get; }
    }
}
