using MyWeb.DAL;
using MyWeb.Model;
using System.Collections.Generic;

namespace MyWeb.BLL
{
    public class ParameterBLL
    {
        public List<ParamterModel> Get_Parameter(string paramterCode)
        {
            ParameterDAL DAL = new ParameterDAL();
            return DAL.Get_Paramter(paramterCode);
        }
    }
}