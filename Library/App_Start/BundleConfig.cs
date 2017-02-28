using System.Web;
using System.Web.Optimization;

namespace Library
{
    public class BundleConfig
    {
        // 如需 Bundling 的詳細資訊，請造訪 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // 準備好實際執行時，請使用 http://modernizr.com 上的建置工具，只選擇您需要的測試。
            bundles.Add(new ScriptBundle("~/BookIndex/js").Include(
                        "~/js/jquery.min.js",
                        "~/js/skel.min.js",
                        "~/js/util.js",
                        "~/js/main.js",
                        "~/js/UploadFile.js"));
            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/js/lib/jquery-{version}-min.js"));
            bundles.Add(new ScriptBundle("~/Bootstrap/js").Include(
                        "~/js/lib/bootstrap-min.js"));

            bundles.Add(new StyleBundle("~/Bootstrap").Include(
                        "~/Style/lib/bootstrap-min.css"));
            bundles.Add(new StyleBundle("~/BookIndex/css").Include(
                        "~/Style/PagedList.css",
                        "~/Style/main.css"));
        }
    }
}