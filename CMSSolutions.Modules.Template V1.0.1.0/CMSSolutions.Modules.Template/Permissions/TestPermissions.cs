using System.Collections.Generic;
using CMSSolutions.Environment.Extensions;
using CMSSolutions.Environment.Extensions.Models;
using CMSSolutions.Web.Security.Permissions;

namespace CMSSolutions.Modules.Template.Permissions
{
    [Feature(Extensions.Constants.FeatureModuleTemplate)]
    public class TestPermissions : IPermissionProvider
    {
        public static readonly Permission ManageModuleAdmin = new Permission
        {
            Name = Extensions.Constants.ManageModuleAdmin, 
            Category = "Content Management",
            Description = "Trang module admin"
        };

        public static readonly Permission ManageModuleHome = new Permission
        {
            Name = Extensions.Constants.ManageModuleHome,
            Category = "Content Management",
            Description = "Trang module home"
        };

        public IEnumerable<Permission> GetPermissions()
        {
            yield return ManageModuleAdmin;
            yield return ManageModuleHome;
        }
    }

    public class FeatureProvider : IFeatureProvider
    {
        public IEnumerable<FeatureDescriptor> AvailableFeatures()
        {
            yield return new FeatureDescriptor
            {
                Id = Extensions.Constants.FeatureModuleTemplate,
                Name = Extensions.Constants.FeatureModuleTemplate,
                Category = "Content"
            };
        }
    }
}