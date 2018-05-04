using CMSSolutions.Localization;
using CMSSolutions.Modules.Template.Permissions;
using CMSSolutions.Web.UI.Navigation;

namespace CMSSolutions.Modules.Template.Menus
{
    public class TestNavigationProvider : INavigationProvider
    {
        public Localizer T { get; set; }
        public TestNavigationProvider()
        {
            T = NullLocalizer.Instance;
        }
        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("demo"), "0", item => item
                   .Action("Index", "AdminTest", new { area = Extensions.Constants.FeatureModuleTemplate })
                   .IconCssClass("cx-icon cx-icon-menus").Permission(TestPermissions.ManageModuleAdmin));
        }
    }
}
