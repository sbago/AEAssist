using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace AEAssist.Converters
{
    public class BooleanConverter<T> : IValueConverter
    {
        protected BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        private T True { get; set; }
        private T False { get; set; }

        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool b && b ? True : False;
        }

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T value1 && EqualityComparer<T>.Default.Equals(value1, True);
        }
    }
}