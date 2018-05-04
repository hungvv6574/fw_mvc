using System.IO;
using System.Web.Mvc;

namespace CMSSolutions.Websites.Extensions
{
    public class ViewRenderer
    {
        public ControllerContext Context { get; set; }
        public ViewRenderer()
        {
            
        }

        public ViewRenderer(ControllerContext context)
        {
            Context = context;
        }

        public string RenderView(string viewPath, object model)
        {
            return RenderViewToStringInternal(viewPath, model);
        }

        public string RenderPartialView(string viewPath, object model)
        {
            return RenderViewToStringInternal(viewPath, model, true);
        }

        protected string RenderViewToStringInternal(string viewPath, object model, bool partial = false)
        {
            if (Context == null)
            {
                throw new FileNotFoundException("ControllerContext Could Not Be Found");
            }
            ViewEngineResult viewEngineResult = null;
            if (partial)
            {
                viewEngineResult = ViewEngines.Engines.FindPartialView(Context, viewPath);
            }
            else
            {
                viewEngineResult = ViewEngines.Engines.FindView(Context, viewPath, null);
            }

            if (viewEngineResult == null)
            {
                throw new FileNotFoundException("View Could Not Be Found");
            }

            var view = viewEngineResult.View;
            Context.Controller.ViewData.Model = model;

            string result = null;
            using (var sw = new StringWriter())
            {
                var ctx = new ViewContext(Context, view, Context.Controller.ViewData, Context.Controller.TempData, sw);
                view.Render(ctx, sw);
                result = sw.ToString();
            }

            return result;
        }
    }
}