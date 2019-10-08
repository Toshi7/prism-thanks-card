using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ThanksCard.Modules.LogonCopyright.ViewModels
{
    public class LogonCopyrightViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IRegionManager _regionManager;
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> HelpCommand { get; set; }

        public LogonCopyrightViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this.HelpCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.HelpCommand.Subscribe(e => this.SelectedButton_MouseDown(e));

        }

        void IDisposable.Dispose() { this.disposables.Dispose(); }
        private void SelectedButton_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            this._regionManager.RequestNavigate("ContentRegion", nameof(Help.Views.Help), new NavigationParameters($"id=1"));
        }
    }
}
