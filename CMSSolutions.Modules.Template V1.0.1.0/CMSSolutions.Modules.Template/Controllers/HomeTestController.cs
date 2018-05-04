using System.Web.Mvc;
using CMSSolutions.Environment.Extensions;
using CMSSolutions.Web.Mvc;
using CMSSolutions.Web.Themes;

namespace CMSSolutions.Modules.Template.Controllers
{
    [Themed]
    [Feature(Extensions.Constants.FeatureModuleTemplate)]
    public class HomeTestController : BaseController
    {
        public HomeTestController(IWorkContextAccessor workContextAccessor)
            : base(workContextAccessor)
        {

        }

        [Url("test/demo-module")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
