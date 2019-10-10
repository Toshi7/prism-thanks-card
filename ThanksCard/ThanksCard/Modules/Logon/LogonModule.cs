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
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Views.Logon));
            //var regionMan = containerProvider.Resolve<IRegionManager>();
            //regionMan.RegisterViewWithRegion("ContentRegion", typeof(Views.Logon));
            _regionManager.RegisterViewWithRegion("RegionOnRegion", typeof(Views.Logon));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
