using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel
{
    public partial class LoginViewModel
    {
       public UserModel ToUserModel() {
            return new UserModel() {
                id=this.id,
                Lib_password=this.password,
                Lib_username=this.username
            };
       }
    }
}
