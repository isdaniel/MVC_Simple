using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace LibraryCommon
{
    public class DropDownListHelper
    {
        /// <summary>
        /// 產生下拉選單html(以IDictionary傳入下拉選單的值).
        /// </summary>
        /// <param name="tagName">拉選單的Tag Name</param>
        /// <param name="optionData">下拉選單Option的Text與Value.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <param name="defaultSelectValue">預選值.</param>
        /// <param name="appendOptionLabel">是否加入預設空白選項.</param>
        /// <param name="optionLabel">如果appendOptionLabel為true,optionLabel為第一個項目要顯示的文字,如果沒有指定則顯示[請選擇].</param>
        /// <returns></returns>
        public static string GetDropdownList(string name, IDictionary<string, string> optionData, object htmlAttributes, string defaultSelectValue, bool appendOptionLabel, string optionLabel)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "產生DropDownList時 tag Name 不得為空");
            }
            TagBuilder select = new TagBuilder("select");
            select.Attributes.Add("name", name);
            StringBuilder renderHtmlTag = new StringBuilder();
            IDictionary<string, string> newOptionData = new Dictionary<string, string>();
            if (appendOptionLabel)
            {
                newOptionData.Add(new KeyValuePair<string, string>(optionLabel ?? "請選擇", ""));
            }
            foreach (var item in optionData)
            {
                newOptionData.Add(item);
            }
            foreach (var option in newOptionData)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.Attributes.Add("value", option.Value);
                if (!string.IsNullOrEmpty(defaultSelectValue) && defaultSelectValue.Equals(option.Value))
                {
                    optionTag.Attributes.Add("selected", "selected");
                }
                optionTag.SetInnerText(option.Key);
                renderHtmlTag.AppendLine(optionTag.ToString(TagRenderMode.Normal));
            }
            select.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            select.InnerHtml = renderHtmlTag.ToString();
            return select.ToString();
        }
    }
}