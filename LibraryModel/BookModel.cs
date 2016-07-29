using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class BookModel
    {
        /// <summary>
        /// 語言
        /// </summary>
        [Required(ErrorMessage = "語言必填")]
        public string BookLanguage { get; set; }

        /// <summary>
        /// 書名
        /// </summary>
        [Required(ErrorMessage = "書名必填")]
        public string bookName { get; set; }

        /// <summary>
        /// 書的種類
        /// </summary>
        [Required(ErrorMessage = "種類必填")]
        public string BookType { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? create_time { get; set; }

        /// <summary>
        /// 序號
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 連接Library_Image資料表
        /// </summary>
        public List<BookImgaeModel> Image { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        [Required(ErrorMessage = "摘要必填")]
        public string summary { get; set; }
    }
}