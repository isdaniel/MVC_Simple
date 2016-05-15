using MyWeb.Common;
using MyWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.DAL;

namespace MyWeb.BLL
{
    public class BookBLL
    {
        readonly static BookDAL dal = new BookDAL();
        public List<BookModel> GetList(PagerMode _PageModel)
        {
            List<SqlParameter> paramters = new List<SqlParameter>();
            StringBuilder sb = new StringBuilder();
            sb.Append(" select a.id,a.bookName,a.summary,b.chinese as BookLanguage,c.chinese  as BookType");
            sb.Append(" from (select ROW_NUMBER() OVER(ORDER BY id) as num ,* from test Where 1=1");
            if (_PageModel.Language.Length != 0)
            {
                sb.Append(" and BookLanguage=@language");
                paramters.Add(new SqlParameter("@language", _PageModel.Language));
            }
            if (_PageModel.Type.Length != 0)
            {
                sb.Append(" and booktype=@type");
                paramters.Add(new SqlParameter("@type", _PageModel.Type));
            }
            sb.Append(" ) as a");
            sb.Append(" inner join parameter as b on a.BookLanguage=b.English");
            sb.Append(" inner join parameter as c on a.BookType=c.English");
            sb.Append(" Order by id");
            return dal.GetList(sb.ToString(), paramters.ToArray());
        }
        public void Add(BookModel model)
        {
            dal.Add(model);
        }
        public void Delete(int Id) {
            dal.Delete(Id);
        }
        public BookModel Edit_Model(int Id)
        {
            return dal.Edit_Model(Id);
        }
        public void Edit(BookModel model) {
            dal.Edit(model);
        }
    }
}