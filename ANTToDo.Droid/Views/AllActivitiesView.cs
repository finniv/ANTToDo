using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "View Activities", NoHistory = true)]
    public class AllActivitiesView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_AllActivities);
        }
    }
}