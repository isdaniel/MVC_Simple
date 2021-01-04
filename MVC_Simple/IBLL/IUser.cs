using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public partial interface IUser
    {


        UserModel GetUserInfo(LoginViewModel model);

        /// <summary>
        /// 返回一個使用者藉由使用者帳號
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        UserModel GetUserByUsername(string username);
        /// <summary>
        /// 新增一個帳戶
        /// 返回 true成功新增 false已重複
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功新增 false已重複</returns>
        bool InsertUserInfo(UserModel model);

    }
}
