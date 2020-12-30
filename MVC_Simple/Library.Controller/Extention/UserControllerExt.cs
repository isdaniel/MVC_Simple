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
            return UserRepositroy.GetListBy(x => x.Username == model.username &&
                                                 x.Password == CipherTextHelper.SHA512Encryption(model.password)).Any();
        }

        #region 新增帳號 + public bool InsertAccount(UserModel model)
        private bool InsertAccount(UserModel model)
        {
            return UserRepositroy.Insert(model);
        }
        #endregion
    }
}
