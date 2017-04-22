using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
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
    }
}
