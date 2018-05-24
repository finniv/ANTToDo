using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ANTToDo.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "View Activities", NoHistory = false)]
    public class StartUpPageView : MvxAppCompatActivity<StartUpPageViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.StartUpPageActivityLayout);
        }
    }
}