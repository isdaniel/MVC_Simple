using LibraryModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace LibraryCommon
{
    #region old code
    //public class UploadMananger
    //{
    //    /// <summary>
    //    /// MB大小
    //    /// </summary>
    //    private const int MB = 1024 * 1024;

    //    private int _fileLimitSize = 0;

    //    private FileType _filter;
    //    /// <summary>
    //    /// 將Html的files填入
    //    /// </summary>
    //    /// <param name="files"></param>
    //    /// <param name="path"></param>
    //    public UploadMananger(FileType filetype,int size= 5) {
    //        _fileLimitSize = size * MB;
    //        _filter = filetype;
    //    }

    //    /// <summary>
    //    /// 將圖片存在path中
    //    /// </summary>
    //    public string SaveImage
    //        (IEnumerable<HttpPostedFileBase> files)
    //    {
    //        string Msg = filter(files);
    //        foreach (var file in files)
    //        {
    //            if (file != null)
    //            {
    //                file.SaveAs(ConfigHelper.ImaPhysicalPath +file.FileName);
    //            }
    //        }
    //        Msg = "儲存成功";
    //        return Msg;
    //    }
    //    /// <summary>
    //    /// 過濾不符合上傳條件
    //    /// </summary>
    //    /// <param name="files"></param>
    //    /// <returns></returns>
    //    private string filter(IEnumerable<HttpPostedFileBase> files)
    //    {
    //        string Msg = "";
    //        Regex reg = new Regex(FilterProvider(_filter));
    //        foreach (var file in files)
    //        {
    //            if (!reg.IsMatch(file.FileName))
    //            {
    //                Msg = "檔案格式出問題";
    //                return Msg;
    //            }
    //            else if (_fileLimitSize > file.ContentLength)
    //            {
    //                Msg = "檔案太大";
    //                return Msg;
    //            }
    //        }
    //        return Msg;
    //    }
    //    /// <summary>
    //    /// 提供上傳檔案的過濾類型
    //    /// </summary>
    //    /// <param name="type"></param>
    //    /// <returns></returns>
    //    private string FilterProvider(FileType type) {
    //        string reg = ".";
    //        switch (type)
    //        {
    //            case FileType.Image:
    //                reg = ".(jpg|gif|png)";
    //                break;
    //            case FileType.Doc:
    //                reg = ".(doc|docx)";
    //                break;
    //            default:
    //                break;
    //        }
    //        return reg;
    //    }
    //} 
    #endregion
    /// <summary>
    /// 提供一個執行的動作
    /// </summary>
    public interface IUpload
    {
        /// <summary>
        /// 是否執行成功
        /// </summary>
        /// <param name="manage"></param>
        /// <returns></returns>
        bool Execute(UploadManage manage);
    }
    /// <summary>
    /// 限制檔案大小
    /// </summary>
    public class FileSize : IUpload
    {
        /// <summary>
        /// MB大小
        /// </summary>
        private const int MB = 1024 * 1024;

        private int _fileLimitSize;
        public FileSize(int size=5) {
            _fileLimitSize = MB * size;
        }
        public bool Execute(UploadManage manage)
        {
            bool IsOk = true;
            foreach (var file in manage.Files)
            {
               if(_fileLimitSize > file.ContentLength)
               {
                    manage.Msg = "檔案太大";
                    IsOk = false;
               }
            }
            return IsOk;
        }
    }
    /// <summary>
    /// 上傳工具
    /// </summary>
    public class Uploader : IUpload
    {
        public bool Execute(UploadManage manage)
        {
            foreach (var file in manage.Files)
            {
                if (file != null)
                {
                    file.SaveAs(ConfigHelper.ImaPhysicalPath + file.FileName);
                }
            }
            return true;
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
    /// <summary>
    /// 檔案上傳管理器
    /// </summary>
    public class UploadManage
    {
        /// <summary>
        /// 上傳結果訊息
        /// </summary>
        public string Msg;
        private List<IUpload> _uploadStep;

        /// <summary>
        /// 上傳的檔案
        /// </summary>
        public IEnumerable<HttpPostedFileBase> Files;
        public UploadManage(IEnumerable<HttpPostedFileBase> files)
        {
            Files = files;
            _uploadStep = new List<IUpload>();
        }
        public UploadManage SetNext(IUpload item)
        {
            _uploadStep.Add(item);
            return this;
        }
        public bool Execute()
        {
            foreach (var next in _uploadStep)
            {
                //如果執行回傳false 就直接回傳
                if (!next.Execute(this))
                {
                    return false;
                }
            }
            return true;
        }
    }

}