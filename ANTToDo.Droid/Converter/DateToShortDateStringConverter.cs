using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;

namespace HiitwayMobile.Droid.Converters
{
    public class DateToShortDateStringConverter : MvxValueConverter<DateTime, string>
    {
        protected override string Convert(DateTime value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString("dd/MM/yyyy");

        }

        protected override DateTime ConvertBack(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return DateTime.UtcNow;
        }
    }
}