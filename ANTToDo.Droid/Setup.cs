using Android.Content;
using ANTToDo.Droid.Services;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Platform;
using ANTToDo.Core;
using ANTToDo.Core.Data;
using ANTToDo.Core.Models;
using ANTToDo.Droid.Converter;

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
            Mvx.RegisterSingleton(new RepositoryService(dbConn));
            return new App();
        }
        protected override void FillValueConverters(MvvmCross.Platform.Converters.IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("VisibilityValueConverter", new VisibilityValueConverter());

        }

    }
}
