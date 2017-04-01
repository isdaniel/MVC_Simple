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
        //-----------------登入操作------------------------------//
        #region 判斷是否在cookie中有userID，如果有存入Session中 +  bool IsUserLogin()
        /// <summary>
        /// 判斷是否在cookie中有userID，如果有存入Session中
        /// </summary>
        /// <returns></returns>
        private bool IsUserLogin()
        {
            //如果Cookie中的UserId中有值
            if (UserCookie != null)
            {
                string UserId = UserCookie.Value;
                //將UserId解密
                string UserIdDecrypt = CipherTextHelper.Decrypt(UserId);
                var user = UserRepositroy.GetUserByUsername(UserIdDecrypt);
                //如果有查詢到UserRepositroy
                if (user != null)
                {
                    //將user訊息存入Session中
                    UserInfo = user;
                    return true;
                }
            }
            return false;
        }
        #endregion
        #region 判斷此帳號密碼和前台驗證是否合法 + bool Login(UserModel model, bool IsValid)
        /// <summary>
        /// 判斷此帳號密碼和前台驗證是否合法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="IsValid"></param>
        /// <returns></returns>
        private bool Login(UserModel model, bool IsValid)
        {
            string password = CipherTextHelper.SHA512Encryption(model.Lib_password);
            //是否符合資料驗證(後端驗證)且判斷是否有次使用者
            var user = UserRepositroy.GetListBy(
                o =>
                o.Lib_username == model.Lib_username &&
                o.Lib_password == password).FirstOrDefault();
            if (IsValid && user != null)
            {
                UserInfo = user;
                //將使用者Id加密傳到前端
                Response.Cookies.Add(CipherTextHelper.SetCookie(model.Lib_username, USERNAME));
                return true;
            }
            return false;
        }
        #endregion
        #region 新增帳號 + public bool InsertAccount(UserModel model)
        private bool InsertAccount(UserModel model)
        {
            return UserRepositroy.Insert(model);
        }
        #endregion
    }
}
