using System.Web.Mvc;
using CMSSolutions.Environment.Extensions;
using CMSSolutions.Web.Mvc;
using CMSSolutions.Web.Themes;

namespace CMSSolutions.Modules.Template.Controllers
{
    [Authorize]
    [Themed(IsDashboard = true)]
    [Feature(Extensions.Constants.FeatureModuleTemplate)]
    public class AdminTestController : BaseController
    {
        public AdminTestController(IWorkContextAccessor workContextAccessor) 
            : base(workContextAccessor)
        {
            
        }

        [Url("admin/test-module")]
        public ActionResult Index()
        {  
            return View();
        }
    }
}
