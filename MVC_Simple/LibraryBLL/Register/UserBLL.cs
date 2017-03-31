using LibraryCommon;
using LibraryModel;
using System;
using System.Linq;
using System.Collections.Generic;
using WarehouseDAL;
using IBLL;
using IDAL;

namespace LibraryBLL
{
    public class UserBLL:IUser
    {
        private IDALWarehouse dal = new DALWarehouse();

        public IEnumerable<UserModel> GetListBy(Func<UserModel, bool> predicate)
        {
           return dal.User.GetListBy(predicate);
        }

        /// <summary>
        /// 確認是否有此使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns>true有此使用者 false無此使用的</returns>
        public UserModel GetUser(UserModel model)
        {
            model.Lib_password = CipherTextHelper.SHA512Encryption(model.Lib_password);
            var m = dal.User.GetListBy
                (o => o.Lib_username == model.Lib_username);
            return m.FirstOrDefault();
        }
        /// <summary>
        /// 返回一個使用者藉由使用者帳號
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUserByUsername(string username)
        {
            var m = dal.User.GetListBy
                (o => o.Lib_username == username).FirstOrDefault();
            return m;

        }
        /// <summary>
        /// 新增一個帳戶
        /// 返回 true成功新增 false已重複
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true成功新增 false已重複</returns>
        public bool Insert(UserModel model)
        {
            bool IsInsert = false;
            //找尋是否有此帳戶
            var user = GetUserByUserName(model.Lib_username);
            //找尋是否已有在資料庫
            if (user == null)
            {
                //進行加密
                model.Lib_password = CipherTextHelper.SHA512Encryption(model.Lib_password);
                dal.User.Insert(model);
                IsInsert = true;
            }
            return IsInsert;
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
            model = GetUserByUserName(model.Lib_username);//找尋是否已有在資料庫
            if (model != null)
            {
                dal.User.Update(model);
                IsModify = true;
            }
            return IsModify;
        }
        private UserModel GetUserByUserName(string username) {
            return dal.User.GetListBy
               (u => u.Lib_username == username).FirstOrDefault();
        }
    }
}