using System;
using System.Globalization;
using System.Windows.Data;

namespace TestWPF.Converter
{
    [ValueConversion(typeof(DateTime), typeof(string))]
    class ConvertFromDateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int now = DateTime.Now.Year;
            DateTime tempDate = (DateTime)value;
            int bdate = tempDate.Year;
            value = now - bdate;
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value);
        }
    }
}