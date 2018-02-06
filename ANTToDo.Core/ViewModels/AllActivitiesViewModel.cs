using System;
using System.Collections.Generic;
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
    public class AllActivitiesViewModel: MvxViewModel
    {
        public List<Activities> AllActivitieses { get; set; }

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
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


        public void Init()
        {
            try
            {
                Task<List<Activities>> result = Mvx.Resolve<Repository>().GetAllActivities();
                result.Wait();
                AllActivitieses = result.Result;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
            
        }
    }
}
