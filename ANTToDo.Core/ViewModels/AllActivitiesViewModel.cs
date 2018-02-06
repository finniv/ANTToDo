using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ANTToDo.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core.ViewModels
{
    public class AllActivitiesViewModel: MvxViewModel,IMotionViewModel
    {
        public List<Activities> AllActivitieses { get; set; }

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }


        private string _addButtonText;
        public string AddButtonText
        {
            get { return _addButtonText; }
            set { _addButtonText = "ADD"; }
        }



        public ICommand NavigateToDetailCommand
        {
            get
            {
                return new MvxCommand<Activities>(item =>
                {
                    ShowViewModel<DetailViewModel>(item);
                });
            }
        }

        public ICommand AddActivities
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<DetailViewModel>(new Activities()));
            }
        }

        public void Init()
        {
            try
            {
                Task<List<Activities>> result = Mvx.Resolve<Repository>().GetAllActivities();
                AllActivitieses = result.Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

        }

        public void OnSwipe(bool swipeRight)
        {
            Task<List<Activities>> result = Mvx.Resolve<Repository>().GetAllActivities();
            AllActivitieses = result.Result;
        }
    }
}
