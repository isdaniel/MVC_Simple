using System;
using System.Collections.Generic;
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
        public string chinese { get; set; }

        /// <summary>
        /// 參數英文
        /// </summary>
        public string English { get; set; }

        /// <summary>
        /// 參數類別
        /// </summary>

        /// <summary>
        /// 編號
        /// </summary>
        public int id { get; set; }

        public string parametertype { get; set; }
    }
}