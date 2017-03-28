using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public partial class LoginViewModel
    {
        public int id { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        [StringLength(10, MinimumLength = 6, ErrorMessage = "密碼需6~10碼")]
        [Required(ErrorMessage = "密碼不能為空")]
        public string password { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required(ErrorMessage = "帳號不能為空")]
        public string username { get; set; }

        /// <summary>
        /// 記住密碼
        /// </summary>
        public bool IsRemember { get; set; }
    }
}
