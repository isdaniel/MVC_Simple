using LibraryCommon;
using LibraryModel;
using System;
using System.Linq;
using System.Collections.Generic;
using IBLL;
using IDAL;
using LibraryDAL;

namespace LibraryBLL
{
    public class UserBLL:IUser
    {

        private IUserDAL _userDal = new UserDAL();

        public UserModel GetUserInfo(LoginViewModel model)
        {
           return _userDal.GetListBy(x => x.Username == model.username &&
                                          x.Password.Equals(CipherTextHelper.SHA512Encryption(model.password), StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        /// <summary>
        /// 返回一個使用者藉由使用者帳號
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUserByUsername(string username)
        {
            var m = _userDal.GetListBy
                (o => o.Username == username).FirstOrDefault();
            return m;

        }
        /// <summary>
        /// 新增一個帳戶
        /// 返回 true成功新增 false已重複
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功新增 false已重複</returns>
        public bool InsertUserInfo(UserModel model)
        {
            bool result = GetUserByUserName(model.Username) != null;
            //找尋是否有此帳戶
            
            //找尋是否已有在資料庫
            if (!result)
            {
                //進行hash
                model.Password = CipherTextHelper.SHA512Encryption(model.Password);
                result = _userDal.Insert(model);
            }

            return result;
        }


        private UserModel GetUserByUserName(string username) {
            return _userDal.GetListBy
               (u => u.Username == username).FirstOrDefault();
        }
    }
}