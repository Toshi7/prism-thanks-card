using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ThanksCard.Modules.ThanksCardCreate.ViewModels
{
    public class ThanksCardCreateViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IRegionManager _regionManager;
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();
        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> CancelCommand { get; set; }

        public ThanksCardCreateViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;         
            this.CancelCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.CancelCommand.Subscribe(e => this.SelectedCancel_Button_MouseDown(e));

        }

        void IDisposable.Dispose() { this.disposables.Dispose(); }
        private void SelectedCancel_Button_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardList.Views.ThanksCardList), new NavigationParameters($"id=1"));
        }
    }
}
