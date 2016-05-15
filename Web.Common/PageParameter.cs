using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeb.Common
{
    /// <summary>
    /// 定義分頁所需的屬性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class PageParameter<T, TKey> where T : class
    {
        public Func<T, bool> where { get; set; }
        public Func<T, TKey> orderby { get; set; }
        public Func<T, dynamic> select { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public bool IsDesc { get; set; }
    }
}
