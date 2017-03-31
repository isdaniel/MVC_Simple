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
    public partial class ParameterDAL:BaseDAL<Parameter>, 
        IParameterDAL
    {
    }
}