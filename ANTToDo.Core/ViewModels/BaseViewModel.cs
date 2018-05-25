using ANTToDo.Core.Data;
using ANTToDo.Core.Interfaces;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ANTToDo.Core.ViewModels
{
    public interface IBaseViewModel
    {
    }

    public abstract class BaseViewModel : MvxViewModel, IBaseViewModel
    {
        public IMvxNavigationService navigationService;
        public IRepositoryService repositoryService;
        public BaseViewModel(IMvxNavigationService _navigationService)
        {
            navigationService = _navigationService;
            repositoryService = Mvx.Resolve<RepositoryService>();
        }
        

        public override Task Initialize() => base.Initialize();
        public override void Prepare() => base.Prepare();
        public override void RaiseAllPropertiesChanged() => base.RaiseAllPropertiesChanged();
        public override void RaisePropertyChanged(PropertyChangedEventArgs changedArgs) => base.RaisePropertyChanged(changedArgs);
        public override void Start() => base.Start();
        public override string ToString() => base.ToString();
        public override void ViewAppeared() => base.ViewAppeared();
        public override void ViewAppearing() => base.ViewAppearing();
        public override void ViewCreated() => base.ViewCreated();
        public override void ViewDestroy(bool viewFinishing = true) => base.ViewDestroy(viewFinishing);
        public override void ViewDisappeared() => base.ViewDisappeared();
        public override void ViewDisappearing() => base.ViewDisappearing();
        protected override void InitFromBundle(IMvxBundle parameters) => base.InitFromBundle(parameters);
        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs) => base.InterceptRaisePropertyChanged(changedArgs);
        protected override void ReloadFromBundle(IMvxBundle state) => base.ReloadFromBundle(state);
        protected override void SaveStateToBundle(IMvxBundle bundle) => base.SaveStateToBundle(bundle);
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) => base.SetProperty(ref storage, value, propertyName);
        public void Close()
        {

        }
    }

    public abstract class BaseViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>, IBaseViewModel
       where TParameter : class
    {
        protected TParameter _parameter;
        protected IMvxNavigationService _navigationService;
        public IRepositoryService _repository;

        public BaseViewModel(IMvxNavigationService navigationService,IRepositoryService repositoryService)
        {
            _repository = repositoryService;
            _navigationService = navigationService;
        }

        protected BaseViewModel(IMvxNavigationService navigationService)
        {
            _repository = Mvx.Resolve<RepositoryService>();
            _navigationService = navigationService;
        }

        public override void Prepare(TParameter parameter)
        {
            _parameter = parameter;
        }
    }
}
