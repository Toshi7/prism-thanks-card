using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ThanksCard.Modules.Logon.ViewModels
{
    public class LogonViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IRegionManager _regionManager;
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> LogonCommand { get; set; }

        public LogonViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this.LogonCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.LogonCommand.Subscribe(e => this.SelectedButton_MouseDown(e));

        }

        void IDisposable.Dispose() { this.disposables.Dispose(); }
        private void SelectedButton_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardList.Views.ThanksCardList), new NavigationParameters($"id=1"));
            this._regionManager.RequestNavigate("HeaderRegion", nameof(LogonUser.Views.LogonUser), new NavigationParameters($"id=1"));
            this._regionManager.RequestNavigate("FooterRegion", nameof(LogonCopyright.Views.LogonCopyright), new NavigationParameters($"id=1"));
            this._regionManager.RequestNavigate("MenuRegion", nameof(LogonMenu.Views.LogonMenu), new NavigationParameters($"id=1"));
        }
    }
}
