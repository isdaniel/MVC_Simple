using LibraryModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryCommon
{
    public class UploadFileHelper
    {
        /// <summary>
        /// 檔案
        /// </summary>
        private IEnumerable<HttpPostedFileBase> _Files;

        /// <summary>
        /// 圖片的資料夾位置
        /// </summary>
        private string _ImagePath;

        /// <summary>
        /// 將Html的files填入
        /// </summary>
        /// <param name="files"></param>
        /// <param name="path"></param>
        public UploadFileHelper(
            IEnumerable<HttpPostedFileBase> files, 
            string path)
        {
            if (files == null)//如果沒有檔案就配置一個空的給他 避免報錯
                files = new List<HttpPostedFileBase>();
            this._Files = files;
            this._ImagePath = path;
            _FilesName = new List<string>();
        }

        /// <summary>
        /// 全部的檔名
        /// </summary>
        public List<string> _FilesName { private set; get; }

        /// <summary>
        /// 將圖片路徑塞入Library_BookImgae組中
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public List<Library_BookImgae> BookAddImagePath(int bookId)
        {
            List<Library_BookImgae> list = new List<Library_BookImgae>();
            foreach (var file in _FilesName)
            {
                list.Add(new Library_BookImgae()
                {
                    Image_Path = file,
                    BookId = bookId
                });
            }
            return list;
        }

        /// <summary>
        /// 將圖片存在path中
        /// </summary>
        public void SaveImage()
        {
            foreach (var file in _Files)
            {
                if (file != null)
                {
                    //避免檔案重複在前面加時間作區別
                    string PrefixName =
                      DateTime.Now.Millisecond.ToString() +
                      DateTime.Now.Minute.ToString();
                    //時間和檔名合併
                    var fileName = Path.GetFileName(
                        PrefixName + file.FileName);
                    _FilesName.Add(fileName);
                    var path = Path.Combine(_ImagePath, fileName);
                    file.SaveAs(path);
                }
            }
        }
    }
}