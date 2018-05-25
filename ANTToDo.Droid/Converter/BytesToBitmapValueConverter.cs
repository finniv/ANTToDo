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
    public class BytesToBitmapValueConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            base.Convert(value, targetType, parameter, culture);

            byte[] _value = value as byte[];
            Bitmap bm = BitmapFactory.DecodeByteArray(_value, 0, _value.Length);
            return bm;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            base.ConvertBack(value, targetType, parameter, culture);

            byte[] bitmapData;
            Bitmap bitmap = value as Bitmap;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            return bitmapData;
        }

    }
}