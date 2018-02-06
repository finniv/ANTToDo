using Android.App;
using Android.OS;
using Android.Views;
using ANTToDo.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "View Activities", NoHistory = true)]
    public class AllActivitiesView : MvxActivity, GestureDetector.IOnGestureListener
    {
        private GestureDetector _gestureDetector;

        public bool OnDown(MotionEvent e)
        {
            _gestureDetector.OnTouchEvent(e);
            return true;
        }
        public bool OnFling(MotionEvent e1 , MotionEvent e2 , float velocityX , float velocityY)
        {
            var isSwipingDown = (e2.RawX - e1.RawX) > 0 ? true : false;

            var motionVm = base.ViewModel as IMotionViewModel;
            motionVm.OnSwipe(isSwipingDown);
            return true;
        }

        public void OnLongPress(MotionEvent e)
        {

        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {
            
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_AllActivities);
            _gestureDetector = new GestureDetector(this);
        }
    }
}