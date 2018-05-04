using System.Collections.Generic;
using System.Reflection;
using CMSSolutions.Web.Mvc.Routes;

namespace CMSSolutions.Websites
{
    public class Routes : RouteProviderBase, IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            MapAttributeRoutes(routes, Assembly.GetExecutingAssembly());
        }
    }
}