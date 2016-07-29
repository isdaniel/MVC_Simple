using LibraryDAL;
using LibraryModel;

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
            bool IsInsert = true;
            //找尋是否已有在資料庫
            if (dal.SingleSearchByUserName(model.Lib_username) == null)
            {
                IsInsert = false;
                dal.Add(model);
            }
            return IsInsert;
        }

        /// <summary>
        /// 檢核帳戶是否存在
        /// 返回 true帳戶存在 false帳戶不存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回 true帳戶存在 false帳戶不存在</returns>
        public bool IsUserExist(UserModel model)
        {
            return dal.SingleSearchByUserName(model.Lib_username) == null ? false : true;
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