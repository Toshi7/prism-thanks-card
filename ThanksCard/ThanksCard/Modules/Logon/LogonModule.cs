using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThanksCard.Modules.Logon
{
    public class LogonModule : IModule
    {
        IRegionManager _regionManager;

        public LogonModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("FooterRegion", typeof(Views.Logon));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
