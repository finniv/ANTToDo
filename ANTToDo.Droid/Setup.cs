using Android.Content;
using ANTToDo.Droid.Services;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using ANTToDo.Core;
using ANTToDo.Core.Data;
using ANTToDo.Core.Models;

namespace ANTToDo.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var dbConn = FileAccessHelper.GetLocalFilePath("activities.db3");
            Mvx.RegisterSingleton(new Repository(dbConn));
            return new Core.App();
        }
    }
}
