using CMSSolutions.Localization;
using CMSSolutions.Web.UI.Navigation;
using CMSSolutions.Websites.Permissions;

namespace CMSSolutions.Websites.Menus
{
    public class NavigationProvider : INavigationProvider
    {
        public Localizer T { get; set; }

        public NavigationProvider()
        {
            T = NullLocalizer.Instance;
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Home"), "0", BuildHomeMenu);
        }

        private void BuildHomeMenu(NavigationItemBuilder builder)
        {
            builder.IconCssClass("fa-home")
                .Action("Index", "Admin", new { area = "" })
                .Permission(AdminPermissions.ManagerAdmin);
        }
    }
}