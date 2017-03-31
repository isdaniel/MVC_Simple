using IBLL;
using LibraryBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseBLL
{
    public class BLLWarehouse : IBLLWarehouse
    {
        private IUser _user = null;
        public IUser User
        {
            get
            {
                if (_user == null)
                {
                    _user =new UserBLL();
                }
                return _user;

            }
        }

        private IBook _book = null;
        public IBook Book
        {
            get
            {
                if (_book == null)
                {
                    _book =new BookBLL();
                }
                return _book;

            }
        }

        private IBookImage _bookimage = null;
        public IBookImage BookImage
        {
            get
            {
                if (_bookimage == null)
                {
                    _bookimage = new BookImageBLL();
                }
                return _bookimage;

            }
        }

        private IParameterBLL _parameter = null;
        public IParameterBLL Parameter
        {
            get
            {
                if (_parameter == null)
                {
                    _parameter = new ParameterBLL();
                }
                return _parameter;

            }
        }
    }
}
