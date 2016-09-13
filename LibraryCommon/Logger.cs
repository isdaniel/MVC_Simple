using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    public class Logger
    {
        /// <summary>
        /// config.xml的路徑
        /// </summary>
        private string configPath = ConfigurationManager.AppSettings["LogPath"];

        private ILog log = null;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="type">要寫日誌類別的型態</param>
        public Logger(Type type)
        {
            log = LogManager.GetLogger(type);
            XmlConfigurator.Configure(new FileInfo(configPath + "config.xml"));
        }

        /// <summary>
        /// 寫錯誤日誌
        /// </summary>
        /// <param name="Content">錯誤內容</param>
        /// <param name="ex">錯誤訊息</param>
        public void WriteErrorLog(string Content, Exception ex)
        {
            log.Error(Content, ex);
        }

        /// <summary>
        /// 寫成功日誌
        /// </summary>
        /// <param name="Contnet">成功內容</param>
        public void WriteSusseccLog(string Contnet)
        {
            log.Info(Contnet);
        }
    }
}