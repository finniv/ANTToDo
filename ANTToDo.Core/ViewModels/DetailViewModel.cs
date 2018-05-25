using System;
using System.Windows.Input;
using ANTToDo.Core.Data;
using ANTToDo.Core.Models;
using ANTToDo.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class DetailViewModel : BaseViewModel<Activities,Status>
    {
        private Activities _activities;

        public DetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            DatePickerPopup = false;
            _activities.ActivitiesDate = DateTime.Now;
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

        private DateTime _dateOfTask;
        public DateTime DateOfTask
        {
            get { return _dateOfTask; }
            set
            {
                _dateOfTask = value;
                RaisePropertyChanged("DateOfTask");
            }
        }
        private bool _datePickerPopup;
        public bool DatePickerPopup
        {
            get { return _datePickerPopup; }
            set
            {
                _datePickerPopup = value;
                RaisePropertyChanged("DatePickerPopup");
            }
        }

        public  string DetailImgUrl
        {
            get { return _activities.ImgPath;}
            set { _activities.ImgPath = ImgPathHolder.Current; RaisePropertyChanged("DetailImgUrl"); }
        }
        
        
        private string _detailDescription = new ImgPathHolder().ImgPathString;
        public string DetailDescription
        {
            get { return _activities.ActivitiesDescription; }
            set
            {
                _activities.ActivitiesDescription = _detailDescription;
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
                return new MvxCommand(async () =>
                {
                     _repository.DeleteActivities(_activities);
                    _navigationService.Close(this , Status.Update);
                });
            }
        }
        public ICommand CancelDateCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    DatePickerPopup = false;
                    
                });
            }
        }
        public ICommand SaveDateCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    DatePickerPopup = false;
                });
            }
        }

        public ICommand PickDateOfTaskCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    DatePickerPopup= true;
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    _activities.ImgPath = ImgPathHolder.Current;
                    if (!isNewActivities)
                    {
                        _repository.UpdateActivities(_activities);
                    }
                    else if (isNewActivities)
                    {
                        _repository.CreateActivities(_activities);
                    }

                    ImgPathHolder.Current = null;
                    await _navigationService.Close(this, Status.Update);
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