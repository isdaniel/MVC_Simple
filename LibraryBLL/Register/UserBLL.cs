using LibraryDAL;
using LibraryDAL.Register;
using LibraryModel;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebMatrix.WebData;

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
                IsInsert = true;
                model.Lib_password = PwdEncryption(model.Lib_password);//進行加密
                dal.Add(model);
            }
            return IsInsert;
        }

        ///// <summary>
        ///// 確認用戶是否在資料庫中
        ///// </summary>
        ///// <returns></returns>
        //public bool IsUser(UserModel model)
        //{
        //    string password = PwdEncryption(model.Lib_password);//密碼加密
        //    return WebSecurity.Login(model.Lib_username, password, true);
        //}

        /// <summary>
        /// 確認是否有此使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true有此使用者 false無此使用的</returns>
        public bool IsUserExite(UserModel model)
        {
            model.Lib_password = PwdEncryption(model.Lib_password);
            using (var concrete = new UserConcrete())
            {
                var m = from i in concrete.User
                        where i.Lib_password == model.Lib_password &&
                              i.Lib_username == model.Lib_username
                        select i;//是否有此使用者
                return m.Count() > 0;
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

        /// <summary>
        /// 密碼進行加密SHA512
        /// </summary>
        /// <param name="pwd">密碼</param>
        /// <returns>返回加密後的密碼</returns>
        private string PwdEncryption(string pwd)
        {
            SHA512 sha512 = new SHA512CryptoServiceProvider();//建立一個SHA512
            byte[] source = Encoding.Default.GetBytes(pwd);//將字串轉為Byte[]
            byte[] crypto = sha512.ComputeHash(source);//進行SHA512加密
            return Convert.ToBase64String(crypto);
        }
    }
}