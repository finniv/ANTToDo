using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ANTToDo.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public ICommand NavigateCreateActivities
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<ActivitiesViewModel>());
            }
        }

        public ICommand NavigateAllActivities
        {
            get
            {
                try
                {

                    return new MvxCommand(() => ShowViewModel<AllActivitiesViewModel>());
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }
            }
        }
    }
}