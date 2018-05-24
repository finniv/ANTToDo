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
        StartUpPageViewModel(IMvxNavigationService navigationService) : base(navigationService)
        {

        }

        public IMvxCommand CalendarViewSelectedCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    Mvx.Resolve<IMvxNavigationService>().Navigate<CalendarPageViewModel>();
                });
            }
        }

        public IMvxCommand DeteilsViewSelectedCommand
        {
            get
            {

                return new MvxCommand(() =>
                {
                    Mvx.Resolve<IMvxNavigationService>().Navigate<DetailViewModel>();
                });
            }
        }
    }
}
