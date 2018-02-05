using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class ActivitiesViewModel:MvxViewModel
    {
        private Activities _activities;

        private string _activitiesTitle;
        public string ActivitiesTitle
        {
            get { return _activities.ActivitiesTitle; }
            set { _activities.ActivitiesTitle = value; RaisePropertyChanged("ActivitiesTitle"); }
        }

        private string _activitiesDescription;
        public string ActivitiesDescription
        {
            get { return _activities.ActivitiesDescription; }
            set { _activities.ActivitiesDescription = value; RaisePropertyChanged("ActivitiesDescription"); }
        }


        private bool _activitiesStatus;
        public bool ActivitiesStatus
        {
            get
            {
                if (_activities.ActivitiesStatus == 0)
                {
                    return false;
                }

                if (_activities.ActivitiesStatus == 1)
                {
                    return true;
                }

                return false;
            }
            set
            {
                if (value)
                {
                    _activities.ActivitiesStatus = 1;
                }

                if (value == false)
                {
                    _activities.ActivitiesStatus = 0;
                }
                RaisePropertyChanged("ActivitiesStatus");
            }
        }



        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand SaveActivities
        {
            get
            {
                return new MvxCommand(() => {
                    
                        Mvx.Resolve<Repository>().CreateActivities(_activities).Wait();
                        Close(this);
                });
            }
        }

        public void Init(Activities activities = null)
        {
            _activities = activities == null ? new Activities() : activities;
            RaiseAllPropertiesChanged();
        }
    }
}
