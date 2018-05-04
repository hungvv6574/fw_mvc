using CMSSolutions.Web.UI;

namespace CMSSolutions.Websites.Extensions
{
    public static class ScriptRegisterExtensions
    {
        public static void IncludeJQuery(this ScriptRegister register)
        {
            register.Include("jquery/jquery.min.js").HasOrder(0);
            register.Include("jquery/jquery-migrate-1.2.1.min.js").HasOrder(0);
        }

        public static void IncludeScrollbar(this ScriptRegister register)
        {
            register.Include("scrollbar/jquery.mCustomScrollbar.concat.min.js");
        }

        public static void IncludeBootstrap(this ScriptRegister register)
        {
            register.Include("bootstrap/bootstrap.min.js");
            register.Include("bootstrap/jquery.bootpag.min.js");
        }

        public static void IncludeChosen(this ScriptRegister register)
        {
            register.Include("chosen/chosen.jquery.min.js");
        }

        public static void IncludeEditor(this ScriptRegister register)
        {
            register.Include("editor/innovaeditor.js");
        }

        public static void IncludeFancyBox(this ScriptRegister register)
        {
            register.Include("fancybox/jquery.fancybox.js");
        }

        public static void IncludeFineUploader(this ScriptRegister register)
        {
            register.Include("fineuploader/jquery.fineuploader-3.5.0.min.js");
        }

        public static void IncludeJQueryUI(this ScriptRegister register)
        {
            register.Include("jqueryui/jquery-ui-1.10.3.min.js");
            register.Include("jqueryui/jquery-ui.unobtrusive-1.0.1.min.js");
            register.Include("jqueryui/jquery-ui-timepicker-addon.js");
        }

        public static void IncludeJQueryValidate(this ScriptRegister register)
        {
            register.Include("jqueryvalidate/jquery.validate.min.js");
            register.Include("jqueryvalidate/jquery.validate.unobtrusive.min.js");
            register.Include("jqueryvalidate/jquery.unobtrusive-ajax.min.js");
        }

        public static void IncludeJQueryvalidationEngine(this ScriptRegister register, string cultureCode)
        {
            register.Include("jqueryvalidationEngine/jquery.validationEngine.js");
            register.Include(string.Format("jqueryvalidationEngine/jquery.validationEngine-{0}.js", cultureCode.Split('-')[0].ToLower()));
        }

        public static void IncludeKnockout(this ScriptRegister register)
        {
            register.Include("knockout/knockout-3.0.0.js");
            register.Include("knockout/knockout.mapping.min.js");
            register.Include("knockout/knockout.validation.js");
            register.Include("knockout/knockout.validation.en-US.js");
            register.Include("knockout/knockout-extensions.js");
        }

        public static void IncludeMetro(this ScriptRegister register)
        {
            register.Include("metro/metro.plugins.min.js");
            register.Include("metro/metro.js");
        }

        public static void IncludePaging(this ScriptRegister register)
        {
            register.Include("jpaging/jquery.paginate.js").AtFoot();
        }

        public static void IncludeModernizr(this ScriptRegister register)
        {
            register.Include("modernizr/modernizr.min.js");
        }

        public static void IncludeHolder(this ScriptRegister register)
        {
            register.Include("holder/holder.js");
        }

        public static void IncludeFullCalendar(this ScriptRegister register)
        {
            register.Include("fullcalendar/fullcalendar.min.js");
        }

        public static void IncludeTrirandGrid(this ScriptRegister register)
        {
            register.Include("jqgrid/jquery.jqGrid.locale-en.js");
            register.Include("jqgrid/jquery.jqGrid.min.js");
        }

        public static void IncludeNivoSlider(this ScriptRegister register)
        {
            register.Include("nivoslider/jquery.nivo.slider.js");
        }

        public static void IncludeColorPicker(this ScriptRegister register)
        {
            register.Include("colorpicker/jquery.simplecolorpicker.js");
        }

        public static void IncludeIcontFontPicker(this ScriptRegister register)
        {
            register.Include("bootstrap/bootstrap-iconpicker.min.js");
        }

        public static void IncludeTwilio(this ScriptRegister register)
        {
            register.Include("//static.twilio.com/libs/twiliojs/1.1/twilio.min.js");
        }

        public static void IncludeElfinder(this ScriptRegister register)
        {
            register.Include("elfinder/elfinder.full.js");
        }

        public static void IncludeNotification(this ScriptRegister register)
        {
            register.Include("notification/notification.min.js");
        }

        public static void IncludePlugin(this ScriptRegister register)
        {
            register.Include("plugin/sparkline/jquery.sparkline.min.js");
            register.Include("plugin/masked-input/jquery.maskedinput.min.js");
            register.Include("plugin/select2/select2.min.js");
            register.Include("plugin/bootstrap-slider/bootstrap-slider.min.js");
            register.Include("plugin/msie-fix/jquery.mb.browser.min.js");
            register.Include("plugin/smartclick/smartclick.js");
        }

        public static void IncludeTooltip(this ScriptRegister register)
        {
            register.Include("tooltip/jquery.tooltip.min.js").AtFoot();
        }

        public static void IncludeThemesMinimal(this ScriptRegister register)
        {
            register.Include("themesminimal/jsharing-widget.js");
        }

        public static void IncludeThemes(this ScriptRegister register)
        {
            register.Include("themes/jarvis.widget.min.js");
            register.Include("themes/app.js");
            register.Include("themes/common.js");
        }

        public static void IncludeThemesDefaults(this ScriptRegister register)
        {
            register.Include("themesdefaults/common.js").AtFoot();
        }
    }
}