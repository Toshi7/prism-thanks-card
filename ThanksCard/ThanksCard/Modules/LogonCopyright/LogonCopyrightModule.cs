using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThanksCard.Modules.LogonCopyright
{
    public class LogonCopyrightModule : IModule
    {
        IRegionManager _regionManager;

        public LogonCopyrightModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("FooterRegion", typeof(Views.LogonCopyright));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
