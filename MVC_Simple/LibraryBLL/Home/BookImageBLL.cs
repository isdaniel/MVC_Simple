using IBLL;
using IDAL;
using LibraryCommon;
using LibraryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WarehouseDAL;

namespace LibraryBLL
{
    public class BookImageBLL:IBookImage
    {
        private IDALWarehouse dal = new DALWarehouse();
        #region MyRegion
        //private string _ImagePath;
        //private ImageDal dal = ImageDal.GetInstance();

        //public ImageBLL(string ImagePath)
        //{
        //    this._ImagePath = ImagePath;
        //}

        //public void AddImage(Library_Book model)
        //{
        //    dal.BookImage.Insert();
        //    //ImageDal imagedal = ImageDal.GetInstance();
        //    //imagedal.InsertFiles(model.Image);
        //}

        ///// <summary>
        ///// 取得圖片路徑
        ///// </summary>
        ///// <returns></returns>
        //public List<Library_BookImgae> GetImageList(Library_Book model)
        //{
        //    string no_pic = _ImagePath + "No_Pic.gif";
        //    List<Library_BookImgae> ImageList = dal.GetImagePath(model);
        //    if (ImageList.Count == 0)
        //    {
        //        ImageList.Add(new Library_BookImgae() { Image_Path = no_pic });
        //    }
        //    else
        //    {
        //        foreach (var item in ImageList)
        //        {
        //            item.Image_Path = _ImagePath + item.Image_Path;
        //        }
        //    }
        //    return ImageList;
        //} 
        #endregion

        public bool Insert(Library_BookImgae model)
        {
           return dal.BookImage.Insert(model);
        }

        public void Update(Library_BookImgae model)
        {
            dal.BookImage.Update(model);
        }

        public void Delete(Library_BookImgae model)
        {
            dal.BookImage.Delete(model);
        }

        public IEnumerable<Library_BookImgae> GetListBy(Func<Library_BookImgae, bool> predicate)
        {
            return dal.BookImage.GetListBy(predicate);
        }
    }
}