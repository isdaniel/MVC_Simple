using IDAL;
using LibraryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDAL
{
    public class DALWarehouse:IDALWarehouse
    {
        private IUserDAL _user = null;
        public IUserDAL User {
            get {
                if (_user==null)
                {
                    _user = new UserDAL();
                }
                return _user;

            }
        }
        private IBookDAL _book = null;
        public IBookDAL Book
        {
            get
            {
                if (_user == null)
                {
                    _book = new BookDAL();
                }
                return _book;

            }
        }
        private IBookImgaeDAL _bookimage = null;
        public IBookImgaeDAL BookImage
        {
            get
            {
                if (_bookimage == null)
                {
                    _bookimage = new ImageDAL();
                }
                return _bookimage;

            }
        }
        private IParameterDAL _parameter = null;
        public IParameterDAL Parameter
        {
            get
            {
                if (_parameter == null)
                {
                    _parameter = new ParameterDAL();
                }
                return _parameter;

            }
        }
    }
}
