using LibraryCommon;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryController
{
    public partial class UserController
    {
        private bool IsUserLogin()
        {
            return UserInfo != null;
        }

        private bool IsLogin(LoginViewModel model)
        {
            var userInfo = UserRepositroy.GetUserInfo(model);

            if (userInfo != null)
            {
                SessionData.UserInfo = new MemberInfoContext()
                {
                    UserName = userInfo.Username,
                    UserId = userInfo.ID
                };
            }

            return SessionData.UserInfo != null;
        }

        #region 新增帳號 + public bool InsertAccount(UserModel model)
        private bool InsertAccount(UserModel model)
        {
            return UserRepositroy.InsertUserInfo(model);
        }
        #endregion
    }
}
