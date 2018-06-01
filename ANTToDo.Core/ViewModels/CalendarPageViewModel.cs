using ANTToDo.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTToDo.Core.ViewModels
{
    public class CalendarPageViewModel : BaseViewModel
    {
        #region LifeCycle
        public CalendarPageViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            ListOfTasksByDate = new MvxObservableCollection<Activities>();
            for (int i = 0; i < 4; i++)
            {
                ListOfTasksByDate.Add(new Activities()
                {
                    Id = 1,
                    ActivitiesDate = DateTime.Now,
                    ActivitiesDescription = "Test Description",
                    ActivitiesStatus = true,
                    ActivitiesTitle = "Test Title",
                    Base64 = "",
                });
            }
            TasksByDate = DateTime.Now;

        }

        public override void Start()
        {
            base.Start();
        }
        public override async Task Initialize()
        {
             AllTasks = await repositoryService.GetAllActivities();
        }
        #endregion
        private DateTime _tasksByDate;
        public DateTime TasksByDate
        {
            get => _tasksByDate;
            set
            {
                SetProperty(ref _tasksByDate, value);

                var swap = new MvxObservableCollection<Activities>();
                foreach (var item in AllTasks)
                {
                    if (item.ActivitiesDate==value)
                    {
                        swap.Add(item);
                    }
                }

                ListOfTasksByDate = swap;
                RaisePropertyChanged("ListOfTasksByDate");
            }
        }
        
        private List<Activities> _allTasks;
        public List<Activities> AllTasks
        {
            get
            {
                if (_allTasks==null)
                {
                    _allTasks = new List<Activities>();
                }
                return _allTasks;
                
            }
            set
            {
                if (_allTasks == null)
                {
                    _allTasks = new List<Activities>();
                }
                SetProperty(ref _allTasks, value);
            }
        }



        private MvxObservableCollection<Activities> _listOfTasksByDate;
        public MvxObservableCollection<Activities> ListOfTasksByDate
        {
            get
            {
                if (_listOfTasksByDate == null)
                {
                    _listOfTasksByDate = new  MvxObservableCollection<Activities>();
                }
                return _listOfTasksByDate;
            }
            set
            {
                if (_listOfTasksByDate == null)
                {
                    _listOfTasksByDate = new MvxObservableCollection<Activities>();
                }
                SetProperty(ref _listOfTasksByDate, value);
            }
        }


    }
}
