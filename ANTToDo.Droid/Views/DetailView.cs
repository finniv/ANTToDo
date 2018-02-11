using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Support.V7.Widget;
using ANTToDo.Core.Services;
using ANTToDo.Core.ViewModels;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Views
{
    [Activity(Label = "Detail View" , NoHistory = false)]
    public class DetailView : MvxAppCompatActivity<DetailViewModel>
    {
        private MvxImageView imgPath;
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

            imgPath = FindViewById<MvxImageView>(Resource.Id.DetailImgView);
            imgPath.Click += delegate
            {
                CreateImageIntent();
            };
            
        }

        private void CreateImageIntent()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(Intent.CreateChooser(imageIntent , "Select photo") , 0);
        }
        protected override void OnActivityResult(int requestCode , Android.App.Result resultCode , Intent data)
        {
            base.OnActivityResult(requestCode , resultCode , data);
            if (resultCode == Android.App.Result.Ok)
            {
                Android.Net.Uri uri = data.Data;
                imgPath.ImageUrl = uri.Path;
                ImgPathHolder.ImgPathString = GetRealPathFromURI(uri);

            }
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