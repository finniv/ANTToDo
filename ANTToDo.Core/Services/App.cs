using ANTToDo.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace ANTToDo.Core.Services
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<AllActivitiesViewModel>();
        }
    }
}
