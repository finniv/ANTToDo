using System.Windows.Input;
using ANTToDo.Core.Models;
using ANTToDo.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel<Activities,Status>
    {
        private Activities _activities;
        public IMvxNavigationService _navigationService;
        public DetailViewModel(IMvxNavigationService navigation)
        {
            _navigationService = navigation;
        }
        private string _detailTitle;
        public string DetailTitle
        {
            get { return _activities.ActivitiesTitle; }
            set
            {
                _activities.ActivitiesTitle = value;
                RaisePropertyChanged("DetailTitle");
            }
        }
        
        public  string DetailImgUrl
        {
            get { return _activities.ImgPath;}
            set { _activities.ImgPath = ImgPathHolder.ImgPathString; RaisePropertyChanged("DetailImgUrl"); }
        }



        private string _detailDescription;
        public string DetailDescription
        {
            get { return _activities.ActivitiesDescription; }
            set
            {
                _activities.ActivitiesDescription = value;
                RaisePropertyChanged("DetailDescription");
            }
        }

        private bool _activitiesStatusDetail;
        public bool ActivitiesStatusDetail
        {
            get { return _activities.ActivitiesStatus; }
            set
            {
                _activities.ActivitiesStatus = value;
                RaisePropertyChanged("ActivitiesStatusDetail");
            }
        }

        public bool isNewActivities { get; set; }


        private bool _editableField;
        public bool EditableField
        {
            get { return _editableField; }
            set
            {
                _editableField = value;
                RaisePropertyChanged("EditableField");
            }
        }

        private bool _editableCheckBox;
        public bool EditableCheckBox
        {
            get
            {
                return _editableCheckBox;
            }
            set
            {
                _editableCheckBox = value;
                RaisePropertyChanged("EditableCheckBox");
            }
        }


        public ICommand DeleteActivities
        {
            get
            {
                return new MvxCommand( () =>
                {
                     Mvx.Resolve<Repository>().DeleteActivities(_activities);
                    _navigationService.Close(this , Status.Update);
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand( () =>
                {
                    _activities.ImgPath = ImgPathHolder.ImgPathString;
                    if (!isNewActivities)
                    {
                        Mvx.Resolve<Repository>().UpdateActivities(_activities);
                    }
                    else if (isNewActivities)
                    {
                        Mvx.Resolve<Repository>().CreateActivities(_activities);
                    }

                    ImgPathHolder.ImgPathString = null;
                    _navigationService.Close(this,Status.Update);
                });
            }
        }

        public void Init(Activities activities)
        {
            ActivitiesChecker(activities);
        }

        private void ActivitiesChecker(Activities activities)
        {
            _activities = activities;
            if (_activities.Id == 0)
            {
                isNewActivities = true;
            }
            else if (_activities.Id != 0)
            {
                isNewActivities = false;
            }

            EditableField = isNewActivities;
            EditableCheckBox = !isNewActivities;
        }

        public override void Prepare(Activities activities)
        {
            ActivitiesChecker(activities);
        }
    }
}