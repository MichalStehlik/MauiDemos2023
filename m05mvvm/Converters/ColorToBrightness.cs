using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m05mvvm.Converters
{
    internal class ColorToBrightness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var typeCode = Type.GetTypeCode(targetType);
            if ((value is Color) && (typeCode == TypeCode.String))
            {
                Color col = (Color)value;
                float brightness = ((col.Red + col.Green + col.Blue) / 3);
                return brightness.ToString();
            }
            if ((value is Color) && (targetType == typeof(Color)))
            {
                Color col = (Color)value;
                float brightness = ((col.Red + col.Green + col.Blue) / 3);
                return new Color(brightness, brightness, brightness);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
