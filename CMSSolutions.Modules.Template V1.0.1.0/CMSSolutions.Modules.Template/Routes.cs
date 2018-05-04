using System.Collections.Generic;
using CMSSolutions.Environment.Extensions;
using CMSSolutions.Modules.Template.Controllers;
using CMSSolutions.Web.Mvc.Routes;

namespace CMSSolutions.Modules.Template
{
    [Feature(Extensions.Constants.FeatureModuleTemplate)]
    public class Routes : RouteProviderBase, IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            MapAttributeRoutes(routes, typeof(AdminTestController));
            MapAttributeRoutes(routes, typeof(HomeTestController));
        }
    }
}