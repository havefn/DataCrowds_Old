using System.Web;
using System.Web.Optimization;

namespace DataCrowds
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                            //"~/Scripts/jquery-{ version }.min.js",
                            "~/Scripts/jquery-1.11.0.min.js",
                            "~/Scripts/jquery.cookie.js"));

            bundles.Add(new ScriptBundle("~/bundles/complement").Include(
                            "~/Scripts/waypoints.min.js",
                            "~/Scripts/jquery.counterup.min.js",
                            "~/Scripts/jquery.parallax-1.1.3.js",
                            "~/Scripts/front.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                            "~/Scripts/bootstrap.js",
                            "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                            "~/Content/bootstrap.css",
                            "~/Content/animate.css",
                            "~/Content/style.default.css",
                            "~/Content/Main.css"));

            bundles.Add(new StyleBundle("~/Content/css/owl").Include(
                            "~/Content/owl.carousel.css",
                            "~/Content/owl.theme.css"));
        }
    }
}
