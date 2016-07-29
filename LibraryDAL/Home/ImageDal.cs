using Dapper;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDAL.Home
{
    public class ImageDal
    {
        private static ImageDal _Insetance = null;
        private IDbConnection _Conn = GetConn.GetInstance();

        private ImageDal()
        {
        }

        public static ImageDal GetInstance()
        {
            if (_Insetance == null)
                _Insetance = new ImageDal();
            return _Insetance;
        }

        public List<BookImgaeModel> GetImagePath(BookModel model)
        {
            return _Conn.Query<BookImgaeModel>("select * from Library_BookImgae where bookid=@id",
                new { id = model.id }).ToList();
        }
    }
}