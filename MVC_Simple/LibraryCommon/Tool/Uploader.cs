using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace LibraryCommon
{
    /// <summary>
    /// 上傳工具
    /// </summary>
    public class Uploader : IUpload
    {
        private ILog _log = LogManager.GetLogger(typeof(Uploader));

        public bool Execute(UploadManage manage)
        {
            bool result = true;

            try
            {
                foreach (var file in manage.Files)
                {
                    file?.SaveAs(ConfigHelper.ImaPhysicalPath + file.FileName);
                }
            }
            catch (Exception e)
            {
                result = false;
                _log.Error(e);
            }
            
            return result;
        }
    }
}
