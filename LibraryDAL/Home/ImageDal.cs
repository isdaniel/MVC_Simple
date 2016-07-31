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

        public List<Library_BookImgae> GetImagePath(Library_Book model)
        {
            return _Conn.Query<Library_BookImgae>("select * from Library_BookImgae where bookid=@id",
                new { id = model.id }).ToList();
        }

        public void InsertFiles(IEnumerable<Library_BookImgae> files)
        {
            string sqlString = @"insert into Library_BookImgae (bookid,image_path) values (@bookid,@image_path)";
            _Conn.Execute(sqlString, files);
        }
    }
}