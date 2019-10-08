using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ThanksCard.Modules.LogonMenu.ViewModels
{
    public class LogonMenuViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IRegionManager _regionManager;
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();
        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> HomeCommand { get; set; }
        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> ThanksCardCreateCommand { get; set; }

        public LogonMenuViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            this.HomeCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.HomeCommand.Subscribe(e => this.SelectedHomeButton_MouseDown(e));
            this.ThanksCardCreateCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.ThanksCardCreateCommand.Subscribe(e => this.SelectedCardCreateButton_MouseDown(e));
        }

        void IDisposable.Dispose() { this.disposables.Dispose(); }
        private void SelectedHomeButton_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardList.Views.ThanksCardList), new NavigationParameters($"id=1"));
        }
        private void SelectedCardCreateButton_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardCreate.Views.ThanksCardCreate), new NavigationParameters($"id=1"));
        }
    }
}