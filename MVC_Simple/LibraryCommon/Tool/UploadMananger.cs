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
        public IEnumerable<HttpPostedFileBase> Files { get;private set; }

        public UploadManage(IEnumerable<HttpPostedFileBase> files)
        {
            Files = files ?? new List<EmptyHttpPostedFile>();
            _uploadStep = new List<IUpload>();
        }
        public UploadManage SetNext(IUpload item)
        {
            _uploadStep.Add(item);
            return this;
        }

        /// <summary>
        /// 返回是否上傳成功
        /// </summary>
        /// <returns></returns>
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

    public class EmptyHttpPostedFile : HttpPostedFileBase
    {
        public override void SaveAs(string filename)
        {
            
        }

    }

}