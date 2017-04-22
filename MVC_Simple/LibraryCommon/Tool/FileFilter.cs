using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    /// <summary>
    /// 過濾上傳附檔名
    /// </summary>
    public class FileFilter : IUpload
    {
        FileType _filter;
        public FileFilter(FileType type = FileType.Image)
        {
            _filter = type;
        }
        public bool Execute(UploadManage manage)
        {
            bool IsOk = true;
            Regex reg = new Regex(FilterProvider(_filter));
            foreach (var file in manage.Files)
            {
                if (!reg.IsMatch(file.FileName))
                {
                    manage.Msg = "檔案格式出問題";
                    IsOk = false;
                }
            }
            return IsOk;
        }
        /// <summary>
        /// 提供上傳檔案的過濾類型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string FilterProvider(FileType type)
        {
            string reg = ".";
            switch (type)
            {
                case FileType.Image:
                    reg = ".(jpg|gif|png)";
                    break;
                case FileType.Doc:
                    reg = ".(doc|docx)";
                    break;
                default:
                    break;
            }
            return reg;
        }
    }
}
