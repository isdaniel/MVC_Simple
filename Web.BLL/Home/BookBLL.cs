using MyWeb.DAL;
using MyWeb.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyWeb.BLL
{
    public class BookBLL
    {
        private static readonly BookDAL dal = new BookDAL();

        public void Add(BookModel model)
        {
            dal.Add(model);
        }

        public void Delete(int Id)
        {
            dal.Delete(Id);
        }

        public void Edit(BookModel model)
        {
            dal.Edit(model);
        }

        public BookModel Edit_Model(int Id)
        {
            return dal.Edit_Model(Id);
        }

        public List<BookModel> GetList(PagerMode _PageModel)
        {
            ConditionStrategy LanuageCondition =
                new ConditionStrategy(new SearchLanguage(), _PageModel.Language);
            ConditionStrategy TypeCondition =
                new ConditionStrategy(new SearchType(), _PageModel.Type);
            List<SqlParameter> paramters = new List<SqlParameter>();
            LanuageCondition.getParameter(ref paramters);
            TypeCondition.getParameter(ref paramters);
            StringBuilder sb = new StringBuilder();
            sb.Append(" select a.id,a.bookName,a.summary,b.chinese as BookLanguage,c.chinese  as BookType");
            sb.Append(" from (select ROW_NUMBER() OVER(ORDER BY id) as num ,* from test Where 1=1 ");
            sb.Append(LanuageCondition.getCondition());
            sb.Append(TypeCondition.getCondition());
            sb.Append(" ) as a");
            sb.Append(" inner join parameter as b on a.BookLanguage=b.English");
            sb.Append(" inner join parameter as c on a.BookType=c.English");
            sb.Append(" Order by id");
            return dal.GetList(sb.ToString(), paramters.ToArray());
        }
    }
}