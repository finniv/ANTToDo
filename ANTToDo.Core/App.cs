using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace ANTToDo.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {


            CreatableTypes()
                    .EndingWith("Service")
                    .AsInterfaces()
                    .RegisterAsLazySingleton();
            RegisterCustomAppStart<CustomAppStart>();
            
        }
    }
}
