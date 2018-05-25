using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace ANTToDo.Droid.Helper
{
    public class PhotoGalleryService : Java.Lang.Object
    {
        public MvxAppCompatActivity Activity { get; set; }
        private readonly int _galleryRequestCode = 2;
        private readonly int _takeRequestCode = 1;
        private ImageView _image;
        private byte[] byteArray;

        public PhotoGalleryService(MvxAppCompatActivity activity, ImageView image)
        {
            Activity = activity;
            _image = image;
        }

        public void BtnUpdatePhoto()
        {
            var popup = new PopupMenu(Activity, _image);
            popup.Menu.Add("Camera");
            popup.Menu.Add("Gallery");
            popup.Menu.Add("Cancel");
            popup.MenuItemClick += onMenuItemClicked;
            popup.Show();
        }

        public byte[] OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            try
            {
                //int width = 300;
                //int height = 300;
                if (requestCode == _takeRequestCode && resultCode == (int)Result.Ok)
                {
                    var bitmap = (Bitmap)data.Extras.Get("data");
                    bitmap = Bitmap.CreateScaledBitmap(bitmap, bitmap.Width, bitmap.Height, true);
                    _image.SetImageBitmap(bitmap);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                        byteArray = stream.ToArray();
                        return byteArray;
                    }
                }
                if (requestCode == _galleryRequestCode && resultCode == (int)Result.Ok)
                {
                    var bitmap = MediaStore.Images.Media.GetBitmap(Activity.ContentResolver, data.Data);
                    bitmap = Bitmap.CreateScaledBitmap(bitmap, bitmap.Width, bitmap.Height, true);
                    _image.SetImageBitmap(bitmap);
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Compress(Bitmap.CompressFormat.Jpeg, 0, stream);
                        byteArray = stream.ToArray();
                        return byteArray;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
            return null;
        }

        void onMenuItemClicked(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            var label = e.Item.TitleFormatted.ToString();
            if (label == "Camera")
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                Activity.StartActivityForResult(intent, _takeRequestCode);
            }
            else if (label == "Gallery")
            {
                var intent = new Intent(Intent.ActionPick);
                intent.SetType("image/*");
                intent.PutExtra(Intent.ExtraAllowMultiple, true);
                intent.SetAction(Intent.ActionGetContent);
                Activity.StartActivityForResult(intent, _galleryRequestCode);
            }
        }
    }
}