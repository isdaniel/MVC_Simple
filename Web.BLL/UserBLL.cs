using MyWeb.DAL;
using MyWeb.Model;

namespace MyWeb.BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 驗證是否為合法用戶
        /// </summary>
        /// <param name="model">User模型</param>
        /// <returns></returns>
        public bool IsValidaion(UserModel model)
        {
            UserDAL dal = new UserDAL();
            return dal.User(model).Rows.Count > 0 ? true : false;
        }
    }
}