using MyWeb.Common;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Web.DAL
{
    public class ParameterDAL
    {
       public List<ParamterModel> Get_Paramter(string paramterType){
           StringBuilder sb = new StringBuilder();
           sb.Append("select * from parameter ");
           sb.Append("Where parametertype=@paramtertype");
           DataTable Dt= Sqlhelp.ExecuteDataTable(sb.ToString(),
               new SqlParameter("@paramtertype",paramterType));
           return ParamterList(Dt);
       }
       private List<ParamterModel> ParamterList(DataTable Dt) { 
           List<ParamterModel> list=new List<ParamterModel>();
            foreach(DataRow item in Dt.Rows){
                ParamterModel model = new ParamterModel();
                model.ParameterCode = Common.IsNull_Value(item["English"]);
                model.ParameterContent = Common.IsNull_Value(item["chinese"]);
                list.Add(model);
            }
            return list;
       }
    }
}
