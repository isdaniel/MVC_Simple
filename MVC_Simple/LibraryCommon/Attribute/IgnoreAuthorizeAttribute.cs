using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCommon
{
    /// <summary>
    /// 不需要做權限驗證
    /// </summary>
    public class IgnoreAuthorizeAttribute:Attribute
    {
    }
}
