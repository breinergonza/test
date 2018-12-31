using System.Web.Optimization;

namespace _1_Presentacion_MVC
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Estilos/css").Include(
                "~/assets-backend/plugins/bootstrap/css/bootstrap.min.css",
                "~/assets-backend/css/style.css",
                "~/assets-backend/css/colors/blue.css",
                "~/assets-backend/plugins/bootstrap-datepicker/bootstrap-datepicker.min.css",
                "~/assets-backend/plugins/timepicker/bootstrap-timepicker.min.css",
                "~/assets-backend/plugins/bootstrap-daterangepicker/daterangepicker.css",
                "~/assets-backend/plugins/dropify/dist/css/dropify.min.css"
            ));

            bundles.Add(new ScriptBundle("~/scripts-1/js").Include(
                "~/assets-backend/plugins/jquery/jquery.min.js",
                "~/assets-backend/plugins/bootstrap/js/tether.min.js",
                "~/assets-backend/plugins/bootstrap/js/bootstrap.min.js",
                "~/assets-backend/js/jquery.slimscroll.js",
                "~/assets-backend/js/waves.js",
                "~/assets-backend/js/sidebarmenu.js",
                "~/assets-backend/plugins/sticky-kit-master/dist/sticky-kit.min.js",
                "~/assets-backend/plugins/sparkline/jquery.sparkline.min.js",
                "~/assets-backend/js/custom.min.js",
                "~/assets-backend/plugins/styleswitcher/jQuery.style.switcher.js",
                "~/assets-backend/plugins/datatables/jquery.dataTables.min.js"
            ));

            bundles.Add(new ScriptBundle("~/scripts-2/js").Include(
                "~/assets-backend/plugins/moment/moment.js",
                "~/assets-backend/plugins/bootstrap-material-datetimepicker/js/bootstrap-material-datetimepicker.js",
                "~/assets-backend/plugins/clockpicker/dist/jquery-clockpicker.min.js",
                "~/assets-backend/plugins/jquery-asColorPicker-master/libs/jquery-asColor.js",
                "~/assets-backend/plugins/jquery-asColorPicker-master/libs/jquery-asGradient.js",
                "~/assets-backend/plugins/jquery-asColorPicker-master/dist/jquery-asColorPicker.min.js",
                "~/assets-backend/plugins/bootstrap-datepicker/bootstrap-datepicker.min.js",
                "~/assets-backend/plugins/timepicker/bootstrap-timepicker.min.js",
                "~/assets-backend/plugins/bootstrap-daterangepicker/daterangepicker.js",
                "~/assets-backend/plugins/dropify/dist/js/dropify.min.js",
                "~/assets-backend/js/custom.min.js",
                "~/assets-backend/js/validation.js"
            ));
        }
    }
}