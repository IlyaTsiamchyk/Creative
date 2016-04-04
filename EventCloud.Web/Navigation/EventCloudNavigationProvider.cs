using Abp.Application.Navigation;
using Abp.Localization;

namespace EventCloud.Web.Navigation
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class EventCloudNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        AppPageNames.Creatives,
                        new LocalizableString("Creatives", EventCloudConsts.LocalizationSourceName),
                        url: "#/creatives",
                        icon: "fa fa-calendar-check-o"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        AppPageNames.Home,
                        new LocalizableString("Home", EventCloudConsts.LocalizationSourceName),
                        url: "#/user/",
                        icon: "fa fa-home"
                        )
                );
        }
    }
}
