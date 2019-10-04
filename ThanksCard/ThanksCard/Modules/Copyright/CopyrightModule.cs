using Prism.Commands;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ThanksCard.Modules.Copyright
{
    public class CopyrightModule : IModule
    {
        IRegionManager _regionManager;

        public CopyrightModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("FooterRegion", typeof(Views.Copyright));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}
