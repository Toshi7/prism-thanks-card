using ThanksCard.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using ThanksCard.Modules.ThanksCardMain;
using ThanksCard.Modules.ThanksCardCreate;
using ThanksCard.Modules.Logon;
using ThanksCard.Modules.LogonUser;
using ThanksCard.Modules.Copyright;
using ThanksCard.Modules.LogonCopyright;
using ThanksCard.Modules.LogonMenu;

namespace ThanksCard
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.ThanksCardCreate.Views.ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.ThanksCardMain.Views.ThanksCardMain>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.LogonUser.Views.LogonUser>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.LogonMenu.Views.LogonMenu>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.LogonCopyright.Views.LogonCopyright>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.Help.Views.Help>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.ThanksCardList.Views.ThanksCardList>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<ThanksCardMainModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<ThanksCardCreateModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<LogonModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<LogonUserModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<LogonMenuModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<CopyrightModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<LogonCopyrightModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<HelpModule>(InitializationMode.WhenAvailable);
            //moduleCatalog.AddModule<ThanksCardListModule>(InitializationMode.WhenAvailable);
        }
    }
}
