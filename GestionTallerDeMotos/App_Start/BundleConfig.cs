using System.Web.Optimization;

namespace GestionTallerDeMotos
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/menu-responsive.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.tableTools.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/dataTables.buttons.js",
                        "~/Scripts/DataTables/buttons.flash.js",
                        "~/Scripts/DataTables/buttons.print.js",                        
                        "~/Scripts/pdfmake.js",
                        "~/Scripts/vfs_fonts.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/DataTables/buttons.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/jquery.dataTables.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/DataTables/css/buttons.bootstrap.css",
                      "~/Content/DataTables/css/dataTables.tableTools.css",
                      "~/Content/FontAwesome-4.7.0/css/font-awesome.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
