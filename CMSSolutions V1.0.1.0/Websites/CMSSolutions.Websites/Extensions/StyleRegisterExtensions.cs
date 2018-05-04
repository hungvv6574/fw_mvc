using CMSSolutions.Web.UI;

namespace CMSSolutions.Websites.Extensions
{
    public static class StyleRegisterExtensions
    {
        public static void IncludeBootstrap(this StyleRegister register)
        {
            register.Include("bootstrap/bootstrap.min.css");
            register.Include("bootstrap/bootstrap-theme.min.css");
        }

        public static void IncludeScrollbar(this StyleRegister register)
        {
            register.Include("scrollbar/jquery.mCustomScrollbar.css");
        }

        public static void IncludeFancyBox(this StyleRegister register)
        {
            register.Include("fancybox/jquery.fancybox.css");
        }

        public static void IncludeJQueryUI(this StyleRegister register)
        {
            register.Include("jqueryui/jquery-ui-1.10.3.custom.css");
            register.Include("jqueryui/jquery-ui-1.10.3.theme.css");
            register.Include("jqueryui/jquery.ui.1.10.3.ie.css");
            register.Include("jqueryui/jquery-ui-timepicker-addon.css");
        }

        public static void IncludeFullCalendar(this StyleRegister register)
        {
            register.Include("fullcalendar/fullcalendar.css");
            register.Include("fullcalendar/fullcalendar.print.css");
            register.Include("smoothness/jquery-ui-1.10.3.custom.css");
        }

        public static void IncludeChosen(this StyleRegister register)
        {
            register.Include("chosen/chosen.css");
        }

        public static void IncludeColorPicker(this StyleRegister register)
        {
            register.Include("colorpicker/jquery.simplecolorpicker.css");
        }

        public static void IncludeIcontFontPicker(this StyleRegister register)
        {
            register.Include("bootstrap/bootstrap-iconpicker.min.css");
        }

        public static void IncludeFineUploader(this StyleRegister register)
        {
            register.Include("fineuploader/fineuploader-3.4.1.css");
        }

        public static void IncludeJQueryValidate(this StyleRegister register)
        {
            register.Include("jqueryvalidate/validationEngine.jquery.css");
        }

        public static void IncludeJQueryvalidationEngine(this StyleRegister register)
        {
            register.Include("jqueryvalidationEngine/validationEngine.jquery.css");
        }

        public static void IncludeMetro(this StyleRegister register)
        {
            register.Include("metro/metro.css");
        }

        public static void IncludePaging(this StyleRegister register)
        {
            register.Include("paging/page.css");
        }

        public static void IncludeElfinder(this StyleRegister register)
        {
            register.Include("elfinder/elfinder.min.css");
            register.Include("elfinder/elfinder.MacOS.css");
        }

        public static void IncludeTrirandGrid(this StyleRegister register)
        {
            register.Include("jqgrid/ui.jqgrid.css");
        }

        public static void IncludeSmoothness(this StyleRegister register)
        {
            register.Include("smoothness/jquery-ui-1.10.3.custom.css");
        }

        public static void IncludeNivoSlider(this StyleRegister register)
        {
            register.Include("nivoslider/nivo-slider.css");
            register.Include("nivoslider/default.css");
        }

        public static void IncludeTooltip(this StyleRegister register)
        {
            register.Include("tooltip/jquery.tooltip.css");
        }


        public static void IncludeThemesMinimal(this StyleRegister register)
        {
            register.Include("themesminimal/common.css");
        }

        public static void IncludeThemes(this StyleRegister register)
        {
            register.Include("themes/font-awesome.min.css");
            register.Include("fonts/fonts.googleapis.css");
            register.Include("themes/production.css");
            register.Include("themes/smartadmin-skins.css");
            register.Include("themes/common.css");
            register.Include("themes/box.css");
        }

        public static void IncludeThemesDefaults(this StyleRegister register)
        {
            register.Include("themesdefaults/theme.css");
        }
    }
}