using ThanksCard.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using ThanksCard.Modules.ThanksCardMain.ThanksCardMainTree;
using ThanksCard.Modules.ThanksCardCreate.ThanksCardTree;
using ThanksCard.Modules.Logon;
using ThanksCard.Modules.LogonUser;

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
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.ThanksCardCreate.ThanksCardTree.Views.ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.ThanksCardMain.ThanksCardMainTree.Views.ThanksCardMain>();
            containerRegistry.RegisterForNavigation<ThanksCard.Modules.LogonUser.Views.LogonUser>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ThanksCardMainTreeModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<ThanksCardCreateTreeModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<LogonModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<LogonUserModule>(InitializationMode.WhenAvailable);
        }
    }
}
