using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m06command.Converters
{
    internal class IntToPictureNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                if((int)value < 4)
                {
                    return Pictures[(int)value];
                    /*
                    switch(value) 
                    {
                        case 0: return "vampire.png";
                    }
                    */
                }
            }
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public string[] Pictures { get; set; }
    }
}
