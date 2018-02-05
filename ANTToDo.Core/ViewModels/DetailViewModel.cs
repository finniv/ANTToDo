using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    internal class DetailViewModel:MvxViewModel
    {
        private Activities _activities;

        private string _detailTitle;
        public string DetailTitle
        {
            get { return _activities.ActivitiesTitle; }
            set { _activities.ActivitiesTitle = value; RaisePropertyChanged("DetailTitle"); }
        }


        private string _detailDescription;
        public string DetailDescription
        {
            get { return _activities.ActivitiesDescription; }
            set { _activities.ActivitiesDescription = value; RaisePropertyChanged("DetailDescription"); }
        }

        private bool _activitiesStatusDetail;
        public bool ActivitiesStatusDetail
        {
            get
            {
                if (_activities.ActivitiesStatus==0)
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
                    _activities.ActivitiesStatus=1;
                }

                if (value==false)
                {
                    _activities.ActivitiesStatus = 0;
                }
               
                RaisePropertyChanged("ActivitiesStatusDetail");
            }
        }





        public ICommand DeleteActivities
        {
            get
            {
                return new MvxCommand(() => {

                    Mvx.Resolve<Repository>().DeleteActivities(_activities).Wait();
                    Close(this);
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand(() => {

                    Mvx.Resolve<Repository>().UpdateActivities(_activities).Wait();
                    Close(this);
                });
            }
        }

        public void Init(Activities activities)
        {
            _activities = activities;
        }
    }
}