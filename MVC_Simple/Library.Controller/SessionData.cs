using System.Web;

namespace LibraryController
{
    public class SessionData
    {
        public const string MemberInfoKey = "MemberInfo";

        private static T Get<T>(string key)
            where T : class
        {
            object value = HttpContext.Current.Session[key];

            return value as T;
        }

        private static void Set<T>(string key, T value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static MemberInfoContext UserInfo
        {
            get
            {
                return Get<MemberInfoContext>(MemberInfoKey);
            }
            set
            {
                Set(MemberInfoKey, value);
            }
        }

    }
}