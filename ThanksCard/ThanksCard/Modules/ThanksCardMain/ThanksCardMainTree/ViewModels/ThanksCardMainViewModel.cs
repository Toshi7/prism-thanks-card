using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ThanksCard.Modules.ThanksCardMain.ThanksCardMainTree.ViewModels

{
    public class ThanksCardMainViewModel : BindableBase, IDisposable
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IRegionManager _regionManager;
        private System.Reactive.Disposables.CompositeDisposable disposables = new System.Reactive.Disposables.CompositeDisposable();

        //public DelegateCommand ShowThanksCardCreateCommand { get; private set; }

        //public ICommand ShowThanksCardCreateCommand { get; private set; }
        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> ShowThanksCardCreateCommand { get; set; }

        public ReactiveCommand<RoutedPropertyChangedEventArgs<object>> ShowThanksCardListCommand { get; set; }

        public ThanksCardMainViewModel(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
            //Message = "View A from your Prism Module";
            //this.SelectedButtonMouseDown = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            //this.SelectedButtonMouseDown.Subscribe(e => this.SelectedButton_MouseDown(e));

            //ShowThanksCardCreateCommand = new DelegateCommand(Execute, canExecute);
            this.ShowThanksCardCreateCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.ShowThanksCardCreateCommand.Subscribe(e => this.SelectedCreateButton_MouseDown(e));
            this.ShowThanksCardListCommand = new ReactiveCommand<System.Windows.RoutedPropertyChangedEventArgs<object>>().AddTo(this.disposables);
            this.ShowThanksCardListCommand.Subscribe(e => this.SelectedListButton_MouseDown(e));

        }


        void IDisposable.Dispose() { this.disposables.Dispose(); }
        private void SelectedCreateButton_MouseDown(RoutedPropertyChangedEventArgs<object> x)
        {
            System.Diagnostics.Debug.WriteLine("SelectedButton_MouseDown");
            //this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(ThanksCardCreate.ThanksCardTree.Views.ThanksCardCreate));
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardCreate.ThanksCardTree.Views.ThanksCardCreate), new NavigationParameters($"id=1"));
        }

        private void SelectedListButton_MouseDown(RoutedPropertyChangedEventArgs<object> e)
        {
            System.Diagnostics.Debug.WriteLine("SelectedButton_MouseDown");
            //this._regionManager.RegisterViewWithRegion("ContentRegion", typeof(ThanksCardCreate.ThanksCardTree.Views.ThanksCardCreate));
            this._regionManager.RequestNavigate("ContentRegion", nameof(ThanksCardList.Views.ThanksCardList), new NavigationParameters($"id=1"));
        }
    }
}