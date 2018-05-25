using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using ANTToDo.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "CalendarPageActivity", NoHistory = false)]
    public class CalendarPageView : MvxAppCompatActivity<CalendarPageViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CalendarPageActivityLayout);

        }
        public override View OnCreateView(string name, Context context, IAttributeSet attrs)
        {
            return base.OnCreateView(name, context, attrs);
        }
    }
}