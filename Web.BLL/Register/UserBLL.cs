using MyWeb.DAL;
using MyWeb.Model;

namespace MyWeb.BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 新增一個帳戶
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(UserModel model)
        {
            UserDAL dal = new UserDAL();
            bool IsInsert;
            if (IsValidaion(model))
            {
                IsInsert = false;
            }
            else
            {
                dal.Add(model);
                IsInsert = true;
            }
            return IsInsert;
        }

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