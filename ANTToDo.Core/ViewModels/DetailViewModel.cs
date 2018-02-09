using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel<Activities>
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
            get { return _editableCheckBox; }
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
                return new MvxCommand(() =>
                {
                    Mvx.Resolve<Repository>().DeleteActivities(_activities).Wait();
                    _navigationService.Close(this);
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (!isNewActivities)
                    {
                        Mvx.Resolve<Repository>().UpdateActivities(_activities);
                    }
                    else if (isNewActivities)
                    {
                        Mvx.Resolve<Repository>().CreateActivities(_activities);
                    }

                    _navigationService.Close(this);
                });
            }
        }

        public void Init(Activities activities)
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
            _activities = activities;
        }
    }
}