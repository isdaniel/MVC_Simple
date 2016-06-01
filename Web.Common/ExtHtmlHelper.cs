using MyWeb.Model;
using System;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MyWeb.Common
{
    public static class ExtHtmlHelper
    {
        /// <summary>
        /// 分頁Pager顯示
        /// </summary>
        /// <param name="html"></param>
        /// <param name="pageSize">每頁顯示</param>
        /// <param name="totalCount">總數據量</param>
        /// <returns></returns>
        public static MvcHtmlString Pager(this HtmlHelper html,
            string currentPageStr,
            int pageSize,
            int totalCount,
            PagerMode model)
        {
            int currentPage = 1; //當前頁
            int.TryParse(currentPageStr, out currentPage); //與相應的QueryString
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //總頁數
            var dict = new RouteValueDictionary(html.ViewContext.RouteData.Values);
            dict.Add("Language", model.Language);//增加下拉選單參數
            dict.Add("Type", model.Type);//增加下拉選單參數
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                if (currentPage != 1)
                {//處理首頁
                    dict["page"] = 1;
                    output.AppendFormat("{0} ", html.RouteLink("首頁", dict));
                }
                if (currentPage > 1)
                {//處理上一頁
                    dict["page"] = currentPage - 1;
                    output.Append(html.RouteLink("上一頁", dict));
                }
                else
                {
                    output.Append("上一頁");
                }
                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一頁最多10筆資料
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                        if (currint == i)
                        {//當前頁面
                            output.Append(string.Format("[{0}]", currentPage));
                        }
                        else
                        {//其他頁面
                            dict["page"] = currentPage + i - currint;
                            output.Append(html.RouteLink((currentPage + i - currint).ToString()
                                , dict));
                        }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//處理下一頁
                    dict["page"] = currentPage + 1;
                    output.Append(html.RouteLink("下一頁", dict));
                }
                else
                {
                    output.Append("下一頁");
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    dict["page"] = totalPages;
                    output.Append(html.RouteLink("末頁", dict));
                }
                output.Append(" ");
            }
            output.AppendFormat("{0} / {1}", currentPage, totalPages);//統計資料
            MvcHtmlString mhs = new MvcHtmlString(output.ToString());
            return mhs;
        }
    }
}