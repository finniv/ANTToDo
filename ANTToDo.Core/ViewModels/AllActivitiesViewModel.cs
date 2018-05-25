using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ANTToDo.Core.Data;
using ANTToDo.Core.Interfaces;
using ANTToDo.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace ANTToDo.Core.ViewModels
{
    public class AllActivitiesViewModel : BaseViewModel
    {

        public AllActivitiesViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
        }

        private List<Activities> _allActivitiesBind;
        public List<Activities> AllActivitiesBind
        {
            get { return _allActivitiesBind; }
            set
            {
                _allActivitiesBind = value;
                RaisePropertyChanged("AllActivitiesBind");
            }
        }
       

        private string _addButtonText;
        public string AddButtonText
        {
            get { return _addButtonText; }
            set { _addButtonText = "ADD"; }
        }


        public ICommand NavigateToDetailCommand =>
            new MvxCommand<Activities>(Execute);

        private async void Execute(Activities item)
        {
          var res= await navigationService.Navigate<DetailViewModel, Activities,Status>(item);
            if (res == Status.Update)
            {
                ReloadData();
            }
        }

        public ICommand RefreshOnSwipe
        {
            get
            {
                return new MvxCommand(() => AllActivitiesBind = new List<Activities>
                {
                    new Activities {ActivitiesTitle = "test"},
                    new Activities {ActivitiesTitle = "tesst"}
                });
            }
        }

        private bool _isRefreshing;
        public virtual bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged(() => IsRefreshing);
            }
        }

        public ICommand ReloadCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    IsRefreshing = true;

                    LoadRefreshTestData();

                    IsRefreshing = false;
                });
            }
        }


        MvxCommand _addActivitiesCommand;
        
        public ICommand AddActivitiesCommand
        {
            get
            {
                _addActivitiesCommand = _addActivitiesCommand ?? new MvxCommand(DoAddActivitiesCommand);
                return _addActivitiesCommand;
            }
        }

        private async void DoAddActivitiesCommand()
        {
           var res= await navigationService.Navigate<DetailViewModel,Status>();
            if (res==Status.Update)
            {
                ReloadData();
            }
        }
        

        private void LoadRefreshTestData()
        {
            AllActivitiesBind = new List<Activities>
            {
                new Activities {ActivitiesTitle = "test"},
                new Activities {ActivitiesTitle = "tesst"}
            };
        }

        private void ReloadData()
        {
            Task<List<Activities>> result = repository.GetAllActivities();
            AllActivitiesBind = result.Result;
        }

        public void Init()
        {
            ReloadData();
        }
        
    }
}