using System;
using System.Collections.Generic;
using System.Web;
using CMSSolutions.Web;
using CMSSolutions.Web.UI;
using CMSSolutions.Web.UI.ControlForms;
using CMSSolutions.Websites.Extensions;

namespace CMSSolutions.Websites
{
    public class MvcApplication : HttpApplicationBase
    {
        protected override void OnApplicationStart()
        {
            base.OnApplicationStart();
            ControlFormProvider.DefaultFormProvider = () => new BootstrapControlFormProvider();
        }

        protected override void LookupResources(object sender, ResourcesLookupEventArgs e)
        {

        }

        protected override IEnumerable<Type> GetExportedTypes()
        {
            return typeof(MvcApplication).Assembly.GetExportedTypes();
        }

        protected override IEnumerable<string> GetDependencies()
        {
            yield return Constants.Areas.Dashboard;
            yield return Constants.Areas.Security;
            yield return Constants.Areas.Accounts;
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            var statusCode = 500;
            if (exception.GetType() == typeof(HttpException))
            {
                statusCode = ((HttpException)exception).GetHttpCode();
            }

            Utilities.WriteEventLog(statusCode + ":" + exception.Message);
        }
    }
}