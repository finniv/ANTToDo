using System;
using ANTToDo.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ANTToDo.Core
{
    public class CustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
        private IMvxNavigationService _NavigationService;

        public CustomAppStart(IMvxNavigationService NavigationService)
        {
            if (NavigationService == null)
            {
                throw new ArgumentNullException(nameof(NavigationService));
            }

            _NavigationService = NavigationService;
        }

        public void Start(object hint = null)
        {
            _NavigationService.Navigate<AllActivitiesViewModel>();
        }
    }
}
