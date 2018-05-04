using System.Web.Mvc;

namespace CMSSolutions.Websites.Extensions
{
    public static class HtmlHelper
    {
        public static ContextModels<TModel> InitializeContext<TModel>(this HtmlHelper<TModel> htmlHelper, WorkContext workContext)
        {
            return new ContextModels<TModel>(htmlHelper, workContext);
        }
    }

    public class ContextModels<TModel>
    {
        private readonly HtmlHelper<TModel> html;
        private readonly WorkContext workContext;
        internal ContextModels(HtmlHelper<TModel> html, WorkContext workContext)
        {
            this.html = html;
            this.workContext = workContext;
        }
    }
}