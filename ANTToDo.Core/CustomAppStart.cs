using ANTToDo.Core.ViewModels;
using MvvmCross.Core.ViewModels;

namespace ANTToDo.Core
{
    public class CustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<MainMenuViewModel>();
        }
    }
}
