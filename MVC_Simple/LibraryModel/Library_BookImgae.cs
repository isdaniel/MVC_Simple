using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public class Library_BookImgae
    {
        /// <summary>
        /// 外鍵liabrary_book(Id)
        /// </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary>
        /// 編號
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 圖片創建時間
        /// </summary>
        public DateTime? Image_Date { get; set; }

        /// <summary>
        /// 圖片路徑
        /// </summary>
        public string Image_Path { get; set; }
    }
}