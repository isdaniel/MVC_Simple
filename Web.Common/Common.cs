namespace MyWeb.Common
{
    public static class CommonFunctions
    {
        /// <summary>
        /// 將物件轉成string
        /// </summary>
        /// <param name="obj">要轉成string的物件</param>
        /// <returns></returns>
        public static string IsNull_Value(object obj)
        {
            if (obj == null)
                obj = "";
            return obj.ToString();
        }
    }
}