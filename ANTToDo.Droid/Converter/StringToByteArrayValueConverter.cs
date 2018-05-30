using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace ANTToDo.Droid.Converter
{
    public class StringToByteArrayValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] _value = System.Convert.FromBase64String((string)value);
            Bitmap bm = BitmapFactory.DecodeByteArray(_value, 0, _value.Length);
            return bm;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] bitmapData;
            Bitmap bitmap = value as Bitmap;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            return System.Convert.ToBase64String(bitmapData);
        }
    }
}