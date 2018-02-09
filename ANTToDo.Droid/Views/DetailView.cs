using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using ANTToDo.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "Detail View" , NoHistory = true)]
    public class DetailView : MvxAppCompatActivity<DetailViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_Detail);

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