using LibraryCommon;
using LibraryDAL;
using LibraryDAL.Register;
using LibraryModel;
using System;
using System.Linq;
using System.Text;

namespace LibraryBLL
{
    public class UserBLL
    {
        private static UserDAL dal = UserDAL.GetInstance();

        /// <summary>
        /// 新增一個帳戶
        /// 返回 true成功新增 false已重複
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功新增 false已重複</returns>
        public bool Add(UserModel model)
        {
            bool IsInsert = false;
            //找尋是否已有在資料庫
            if (dal.SingleSearchByUserName(model.Lib_username) == null)
            {
                //進行加密
                model.Lib_password =CipherTextHelper.SHA512Encryption(model.Lib_password);              
                dal.Add(model);
                IsInsert = true;
            }
            return IsInsert;
        }

        /// <summary>
        /// 確認是否有此使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true有此使用者 false無此使用的</returns>
        public UserModel GetUser(UserModel model)
        {
            model.Lib_password = CipherTextHelper.SHA512Encryption(model.Lib_password);
            using (var concrete = new UserConcrete())
            {
                var m = from i in concrete.User
                        where i.Lib_password == model.Lib_password &&
                              i.Lib_username == model.Lib_username
                        select i;//是否有此使用者
                return m.FirstOrDefault();
            }
        }
        /// <summary>
        /// 返回一個使用者藉由使用者帳號
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUserByUsername(string username) {
            using (var concrete = new UserConcrete()) {
                var m = (from i in concrete.User
                        where i.Lib_username == username
                        select i).FirstOrDefault();
                return m;
            }
        }
        /// <summary>
        /// 修改帳戶
        /// 返回 true成功修改 false修改失敗
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功修改 false修改失敗</returns>
        public bool Modify(UserModel model)
        {
            bool IsModify = false;
            model = dal.SingleSearchByUserName(model.Lib_username);//找尋是否已有在資料庫
            if (model != null)
            {
                dal.Modify(model);
                IsModify = true;
            }
            return IsModify;
        }
    }
}