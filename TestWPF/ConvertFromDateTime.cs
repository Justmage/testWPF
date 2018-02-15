using System;
using System.Globalization;
using System.Windows.Data;

namespace TestWPF.Converter
{
    /// <summary>
    /// Реализация конвертера значений из DateTime в string. Используется для отображения "Возраста" в элементе управления DataGrid.
    /// Так же имеет обратную конвертацию из string в DateTime для корректного отображения "Возраста" сотрудника в элементе управления DataGrid.
    /// Не влияет на способ отображения в элементе управления TextBox т.к. он имеет собственную форматировку вывода DateTime.
    /// </summary>
    [ValueConversion(typeof(DateTime), typeof(string))]
    class ConvertFromDateTime : IValueConverter
    {
        /// <summary>
        /// Реализация метода интерфейса IValueConverter для изменения отображения в объекте-приёмнике.
        /// Используется для прямого конвертирования значения DateTime в string из объекта-источника в объекте-приемнике.
        /// Влияет на отображение возраста.
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int now = DateTime.Now.Year;
            DateTime tempDate = (DateTime)value;
            int bdate = tempDate.Year;
            value = now - bdate;
            return value.ToString();
        }

        /// <summary>
        /// Используется для обратного конвертирования значения string в DateTime из объекта-приемника в объект-источник.
        /// Не влияет на способ отображения в элементе управления TextBox т.к. он имеет собственную форматировку вывода DateTime.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value);
        }
    }
}