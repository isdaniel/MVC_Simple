using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
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
}
