using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    /// <summary>
    /// 限制檔案大小
    /// </summary>
    public class Filelimit : IUpload
    {
        /// <summary>
        /// MB大小
        /// </summary>
        private const int MB = 1024 * 1024;

        private int _fileLimitSize;
        public Filelimit(int size = 5)
        {
            _fileLimitSize = MB * size;
        }
        public bool Execute(UploadManage manage)
        {
            bool IsOk = true;
            foreach (var file in manage.Files)
            {
                if (_fileLimitSize > file.ContentLength)
                {
                    manage.Msg = "檔案太大";
                    IsOk = false;
                }
            }
            return IsOk;
        }
    }
}
