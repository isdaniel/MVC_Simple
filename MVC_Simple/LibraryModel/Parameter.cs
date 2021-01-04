using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Parameter
    {
        /// <summary>
        /// 參數中文
        /// </summary>
        [Required]
        public string chinese { get; set; }

        /// <summary>
        /// 參數英文
        /// </summary>
        [Required]
        public string English { get; set; }

        /// <summary>
        /// 編號
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// 參數類別
        /// </summary>
        public DropDownType Parametertype { get; set; }
    }
}