using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Authoriz
{
    public class AuthorizHttpMsg : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //// 產生IPrincipal
            var principal = this.CreateIPrincipal();

            //// 設定IPrincipal
            this.SetPrincipal(principal);

            //// 呼叫base.SendAsync將request傳給inner handler去處理，inner handler非同步處理完會回傳Task<T>的物件
            var result = base.SendAsync(request, cancellationToken);
            return result;
        }

        /// <summary>
        /// 產生IPrincipal的物件
        /// </summary>
        /// <returns>IPrincipal</returns>
        private IPrincipal CreateIPrincipal()
        {
            //// 建立一個使用者名稱為"Kevin"的GenericIdentity物件，同時設定該使用者的角色為"RD"與"QA"
            GenericIdentity identity = new GenericIdentity("Kevin");
            string[] userRoles = { "RD", "QA" };
            GenericPrincipal principal = new GenericPrincipal(identity, userRoles);
            return principal;
        }

        /// <summary>
        /// 將IPrincipal附加到Thread.CurrentPrincipal裡
        /// </summary>
        /// <param name="principal">The principal.</param>
        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
        }
    }
}