using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ANTToDo.Core.ViewModels
{
    public class StartUpPageViewModel : BaseViewModel
    {
        public StartUpPageViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }

        public IMvxCommand CalendarViewSelectedCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    navigationService.Navigate<CalendarPageViewModel>();
                });
            }
        }

        public IMvxCommand DeteilsViewSelectedCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    navigationService.Navigate<DetailViewModel>();
                });
            }
        }
    }
}
