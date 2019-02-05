using System.Web;
using System.Web.Optimization;

namespace CNV_Site
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/AdminLTE/plugins/jquery/jQuery-2.1.3.min.js",  "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/site.css"));
            // plugins | datatables
            bundles.Add(new ScriptBundle("~/Scripts/DataTables").Include(
                                         "~/Scripts/DataTables/jquery.dataTables.min.js",
                                         "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                                         "~/Scripts/DataTables/dataTables.editor.min.js",
                                         "~/Scripts/DataTables/dataTables.select.js",
                                         "~/Scripts/DataTables/dataTables.buttons.js"));

            bundles.Add(new StyleBundle("~/Content/DataTables/css").Include(
                                        "~/Content/DataTables/css/dataTables.bootstrap.css",
                                        "~/Content/DataTables/css/editor.dataTables.css"));

            // plugins | ckeditor
            bundles.Add(new ScriptBundle("~/AdminLTE/plugins/ckeditor/js").Include(
                                         "~/AdminLTE/plugins/ckeditor/js/ckeditor.js"));

        }
    }
}
