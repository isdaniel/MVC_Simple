using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.DAL;

namespace MyWeb.BLL
{
    public class ParameterBLL
    {
        public List<ParamterModel> Get_Parameter(string paramterCode) {
            ParameterDAL DAL = new ParameterDAL();
            return  DAL.Get_Paramter(paramterCode);
        }
    }
}
