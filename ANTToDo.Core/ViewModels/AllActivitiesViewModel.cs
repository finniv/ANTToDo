using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class AllActivitiesViewModel : MvxViewModel
    {
        private List<Activities> _allaActivitiesBind;
        public List<Activities> AllActivitiesBind
        {
            get { return _allaActivitiesBind; }
            set
            {
                _allaActivitiesBind = value;
                RaisePropertyChanged("AllActivitiesBind");
            }
        }


        public IMvxNavigationService _navigationService;
        public AllActivitiesViewModel(IMvxNavigationService navigation)
        {
            _navigationService = navigation;
        }

        private string _addButtonText;
        public string AddButtonText
        {
            get { return _addButtonText; }
            set { _addButtonText = "ADD"; }
        }


        public ICommand NavigateToDetailCommand =>
            new MvxCommand<Activities>(item => _navigationService.Navigate<DetailViewModel , Activities>(item));


        public ICommand AddActivities => new MvxCommand(() => _navigationService.Navigate<DetailViewModel>());

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
            Task<List<Activities>> result = Mvx.Resolve<Repository>().GetAllActivities();
            AllActivitiesBind = result.Result;
        }

        public void Init()
        {
            ReloadData();
        }
    }
}