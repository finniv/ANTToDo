using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Support.V7.Widget;
using ANTToDo.Core.Services;
using ANTToDo.Core.ViewModels;
using ANTToDo.Droid.Helper;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "Detail View" , NoHistory = false)]
    public class DetailView : MvxAppCompatActivity<DetailViewModel>
    {
        private MvxImageView imgPath;
        private PhotoGalleryService galleryService;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.View_detailActivities);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);

            var actionBar = SupportActionBar;
            if (actionBar != null)
            {
                actionBar.SetDisplayHomeAsUpEnabled(true);
            }

            imgPath = FindViewById<MvxImageView>(Resource.Id.DetailImgView);
            galleryService = new PhotoGalleryService(this, imgPath);
            imgPath.Click += delegate
            {
                galleryService.BtnUpdatePhoto();
            };
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var result = galleryService.OnActivityResult(requestCode, (int)resultCode, data);
            if (result == null)
            {
                return;
            }
            ViewModel.SaveNewPhoto(result);
        }
        

        private string GetRealPathFromURI(Android.Net.Uri contentURI)
        {
            ICursor cursor = ContentResolver.Query(contentURI , null , null , null , null);
            cursor.MoveToFirst();
            string path = cursor.GetString(cursor.GetColumnIndex(MediaStore.Files.FileColumns.Data));
            cursor.Close();

            return path;
        }
    }
}