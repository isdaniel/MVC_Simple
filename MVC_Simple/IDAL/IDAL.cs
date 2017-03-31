using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public partial interface IUserDAL:IBaseDAL<UserModel>
    {

    }
    public partial interface IBookDAL : IBaseDAL<Library_Book>
    {
        int InsertGetId(Library_Book model);
    }
    public partial interface IBookImgaeDAL :IBaseDAL<Library_BookImgae>
    {

    }
    public partial interface IParameterDAL :IBaseDAL<Parameter>
    {

    }
}
