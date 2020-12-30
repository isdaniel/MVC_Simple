using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace LibraryCommon
{
    public class CipherTextHelper
    {
        /// <summary>
        /// 設置加密cookie
        /// </summary>
        /// <param name="strEncrypt">要加密內容</param>
        /// <param name="cookieName">cookie名稱</param>
        /// <returns>返回加密cookie</returns>
        public static HttpCookie SetCookie(string strEncrypt, string cookieName) {
            //設置.ASPXAUTH 以便做微軟內建權限
            //FormsAuthentication.SetAuthCookie(strEncrypt,true);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
              strEncrypt,
              DateTime.Now,
              DateTime.Now.AddDays(1),
              true,
              strEncrypt);
            // 將ticket加密
            string Encrypt = FormsAuthentication.Encrypt(ticket);

            // 新增cookie
            HttpCookie cookie = new HttpCookie(cookieName, Encrypt);
            cookie.Expires=DateTime.Now.AddDays(1);
            return cookie;
        }
        /// <summary>
        /// 返回解密資訊
        /// </summary>
        /// <param name="strDecrypt">解密資料</param>
        /// <returns>返回解密資訊</returns>
        public static string Decrypt(string strDecrypt)
        {
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(strDecrypt);
            return ticket.UserData;
        }

        /// <summary>
        /// 進行加密SHA512
        /// </summary>
        /// <param name="pwd">加密內容</param>
        /// <returns>返回加密後的密碼</returns>
        public static string SHA512Encryption(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] source = Encoding.Default.GetBytes(pwd);//將字串轉為Byte[]
            byte[] crypto = md5.ComputeHash(source);//進行MD5加密
            return Convert.ToBase64String(crypto);
        }
    }
}
