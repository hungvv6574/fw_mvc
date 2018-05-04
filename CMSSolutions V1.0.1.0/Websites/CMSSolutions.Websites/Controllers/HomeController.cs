using System.Web.Mvc;
using CMSSolutions.ContentManagement.Dashboard.Services;
using CMSSolutions.Web.Mvc;
using CMSSolutions.Web.Themes;

namespace CMSSolutions.Websites.Controllers
{
    [Themed(IsDashboard = false)]
    public class HomeController : BaseController
    {
        public HomeController(IWorkContextAccessor workContextAccessor) 
            : base(workContextAccessor)
        {

        }

        [Url("", Priority = 10)]
        public ActionResult Index()
        {
            ViewData["Title"] = "";

            return View();
        }
    }
}
