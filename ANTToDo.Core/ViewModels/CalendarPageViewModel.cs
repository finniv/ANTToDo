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
        CalendarPageViewModel(IMvxNavigationService navigationService):base (navigationService)
        {
            ListOfTasksByDate = new MvxObservableCollection<Activities>();
        }

        private DateTime _tasksByDate;
        public DateTime TasksByDate
        {
            get => _tasksByDate;
            set => SetProperty(ref _tasksByDate, value);
        }

        private MvxObservableCollection<Activities> _listOfTasksByDate;
        public MvxObservableCollection<Activities> ListOfTasksByDate
        {
            get => _listOfTasksByDate;
            set => SetProperty(ref _listOfTasksByDate, value);
        }







    }
}
