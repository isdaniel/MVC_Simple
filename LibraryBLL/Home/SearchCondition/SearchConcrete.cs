using LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL.Home.SearchCondition
{
    public class SearchConcrete
    {
        /// <summary>
        /// 參數
        /// </summary>
        public BookSearch_ViewModel _Entity;

        /// <summary>
        /// SQL語法
        /// </summary>
        public StringBuilder sb = new StringBuilder();

        private ISearchContition _Condition = null;

        public SearchConcrete(BookSearch_ViewModel entity)
        {
            this._Entity = entity;
        }

        /// <summary>
        /// 執行下一階段
        /// </summary>
        /// <returns></returns>
        public string Next()
        {
            _Condition.condition(this);
            return sb.ToString();
        }

        /// <summary>
        /// 設置下一階段
        /// </summary>
        /// <param name="condiion">下一階段的實體</param>
        public void SetCondition(ISearchContition condiion)
        {
            _Condition = condiion;
        }
    }
}