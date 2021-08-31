using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace MsgElf.Core.Converters
{
    [ValueConversion(typeof(TimeSpan?), typeof(DateTime?))]
    public class TimeSpanToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var timeSpan = value as TimeSpan?;
            if (timeSpan == null) return null;
            var result = new DateTime(1, 1, 1, timeSpan?.Hours ?? 0, timeSpan?.Minutes ?? 0, timeSpan?.Seconds ?? 0, timeSpan?.Milliseconds ?? 0);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as DateTime?)?.TimeOfDay;
        }
    }
}
