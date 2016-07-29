using Dapper;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Home
{
    public class ParameterDal
    {
        private static ParameterDal _Instance = null;
        private IDbConnection _Conn = GetConn.GetInstance();

        private ParameterDal()
        {
        }

        public static ParameterDal GetInstace()
        {
            if (_Instance == null)
                _Instance = new ParameterDal();
            return _Instance;
        }

        public List<ParameterModel> GetAllParameter()
        {
            return _Conn.Query<ParameterModel>
                ("select english,chinese,Parametertype from parameter").
                ToList();
        }
    }
}