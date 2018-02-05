using Android.App;
using MvvmCross.Droid.Views;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "Create Activities" , NoHistory = true)]
    public class ActivitiesView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
           
            SetContentView(Resource.Layout.View_Activities);
        }
    }
}