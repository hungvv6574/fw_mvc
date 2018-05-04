using System.Web.Mvc;
using CMSSolutions.Caching;
using CMSSolutions.Web.Mvc;
using CMSSolutions.Web.Security.Permissions;
using CMSSolutions.Web.Themes;

namespace CMSSolutions.Websites.Controllers
{
    [Themed(IsDashboard = true), Authorize]
    public class AdminController : BaseController
    {
        private readonly ICacheManager cacheManager;
        private readonly IStaticCacheManager staticCacheManager;
        public AdminController(IWorkContextAccessor workContextAccessor,
            ICacheManager cacheManager,
            IStaticCacheManager staticCacheManager) 
            : base(workContextAccessor)
        {
            this.cacheManager = cacheManager;
            this.staticCacheManager = staticCacheManager;
        }

        [Url("admin")]
        public ActionResult Index()
        {
            if (!CheckPermission(StandardPermissions.DashboardAccess, T("Can't access the dashboard panel.")))
            {
                return new HttpUnauthorizedResult();
            }

            ViewBag.Title = T("Dashboard");

            return View();
        }

        [Url("admin/reset-cache")]
        public virtual ActionResult ResetCache()
        {
            if (cacheManager != null)
            {
                cacheManager.Reset();
            }

            if (staticCacheManager != null)
            {
                staticCacheManager.Reset();
            }

            return RedirectToAction("Index");
        }
    }
}
