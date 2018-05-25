using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using ANTToDo.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Droid.Views;
using static Android.Resource.Color;

namespace ANTToDo.Droid.Views
{
    
    [Activity(Label = "View Activities", NoHistory = false)]
    public class AllActivitiesView : MvxAppCompatActivity<AllActivitiesViewModel>
    {
        private SwipeRefreshLayout swipe;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_AllActivities);

            swipe = FindViewById<SwipeRefreshLayout>(Resource.Id.refresher);
            swipe.SetColorSchemeColors(HoloBlueBright, HoloBlueDark,
                HoloGreenLight, HoloRedLight);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            var actionBar = SupportActionBar;
            if (actionBar != null)
            {
                actionBar.SetDisplayHomeAsUpEnabled(true);
            }
        }
    }
}