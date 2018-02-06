using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    internal class DetailViewModel:MvxViewModel
    {
        private Activities _activities;
        private bool _activitiesIsEmpty;
        
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
            get => _activities.ActivitiesStatus;
            set
            {
                _activities.ActivitiesStatus = value;
                RaisePropertyChanged("ActivitiesStatusDetail");
            }
        }

        private bool _editableCheckBox;
        public bool EditableCheckBox
        {
            get { return _editableCheckBox; }
            set { _editableCheckBox = value; RaisePropertyChanged("EditableCheckBox"); }
        }

        private bool _editableField;
        public bool EditableField
        {
            get { return _editableField; }
            set { _editableField = value; RaisePropertyChanged("EditableField"); }
        }



        public ICommand DeleteActivities
        {
            get
            {
                return new MvxCommand(() => {
                    if(_activities!=null)
                    {
                        Mvx.Resolve<Repository>().DeleteActivities(_activities).Wait();
                    }
                    Close(this);
                    ShowViewModel<AllActivitiesViewModel>();
                });
            }
        }

        public ICommand UpdateActivities
        {
            get
            {
                return new MvxCommand(async () => {
                    if (!_activitiesIsEmpty)
                    {
                        await Mvx.Resolve<Repository>().UpdateActivities(_activities);
                        
                    }

                    if (_activitiesIsEmpty)
                    {
                        await Mvx.Resolve<Repository>().CreateActivities(_activities);
                        
                        
                    }
                    Close(this);
                    ShowViewModel<AllActivitiesViewModel>();
                });
            }
        }

        public void Init(Activities activities)
        {
            _activities = activities;
            if (_activities.Id==0)
            {
                _activitiesIsEmpty = true;
            }

            if (_activities.Id!=0)
            {
                _activitiesIsEmpty = false;
            }

            EditableField = _activitiesIsEmpty;
            EditableCheckBox = !_activitiesIsEmpty;
        }
    }
}