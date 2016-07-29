using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class UserModel
    {
        /// <summary>
        /// 序號
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 上次使用的密碼
        /// </summary>
        public string LastPassWord { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [Range(6, 10, ErrorMessage = "密碼需6~10碼")]
        [Required(ErrorMessage = "密碼不能為空")]
        public string Lib_password { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required(ErrorMessage = "帳號不能為空")]
        public string Lib_username { get; set; }

        /// <summary>
        /// 密碼修改時間
        /// </summary>
        public DateTime? ModifyDate { get; set; }
    }
}