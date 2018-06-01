using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ANTToDo.Core.Data;
using ANTToDo.Core.Models;
using ANTToDo.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class DetailViewModel : BaseViewModel<Activities, Status>
    {
 

        private Activities _activities;
        public Activities Activities
        {
            get => _activities;
            set => SetProperty(ref _activities, value);
        }

        public DetailViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {
            DateOfTasks = DateTime.Now;
               DatePickerPopup = false;
            if (Activities == null)
            {
                Activities = new Activities
                {
                    ActivitiesDate = DateTime.Now
                };
            }
        }

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
        public DateTime DateOfTasks
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
            get { return _activities.Base64; }
            set { _activities.Base64 = ImgPathHolder.Current; RaisePropertyChanged("DetailImgUrl"); }
        }

        private string _detailDescription;
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
                    await _repository.DeleteActivities(_activities);
                    await _navigationService.Close(this, Status.Update);
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
                    _activities.ActivitiesDate = DateOfTasks;
                   RaisePropertyChanged("DateOfTasks");
                });
            }
        }

        public ICommand PickDateOfTaskCommand
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    DatePickerPopup = true;
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand(async () =>
                {
                    try
                    {
                        if (!isNewActivities)
                        {
                            await _repository.UpdateActivities(_activities);
                        }
                        else if (isNewActivities)
                        {
                            await _repository.CreateActivities(_activities);
                        }

                        ImgPathHolder.Current = null;
                        await _navigationService.Close(this, Status.Update);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex); 
                    }
                });
            }
        }

        public void Init(Activities activities)
        {
            ActivitiesChecker(activities);
        }

        public void SaveNewPhoto(byte[] result)
        {
            if (_activities!=null)
            {
                _activities.Base64 = Convert.ToBase64String(result);
            }
        }
        private void ActivitiesChecker(Activities activities)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public override void Prepare(Activities activities)
        {
            ActivitiesChecker(activities);
        }
    }
}