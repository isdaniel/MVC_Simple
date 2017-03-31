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


        IEnumerable<UserModel> GetListBy
            (Func<UserModel, bool> predicate);

        /// <summary>
        /// 確認是否有此使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true有此使用者 false無此使用的</returns>
        UserModel GetUser(UserModel model);
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
        bool Insert(UserModel model);

        /// <summary>
        /// 修改帳戶
        /// 返回 true成功修改 false修改失敗
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功修改 false修改失敗</returns>
        bool Modify(UserModel model);
    }
}
