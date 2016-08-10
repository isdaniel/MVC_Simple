using LibraryDAL.Register;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MVC.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 請確定一個應用程式啟動只起始一次 ASP.NET Simple Membership
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UserConcrete>(null);
                try
                {
                    using (var context = new UserConcrete())
                    {
                        if (!context.Database.Exists())
                        {
                            // 建立沒有 Entity Framework 移轉結構描述的 SimpleMembership 資料庫
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }
                    WebSecurity.InitializeDatabaseConnection("LibraryConn", "Library_UserInfo", "Id", "Lib_username", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("無法起始 ASP.NET Simple Membership 資料庫。如需詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}