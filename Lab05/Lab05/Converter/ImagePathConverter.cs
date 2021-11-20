using Lab05.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Lab05.Converter
{
    class ImagePathConverter : IValueConverter
    {
        Dictionary<string, BitmapImage> cache = new Dictionary<string, BitmapImage>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = $"../Resources/Images/";

            switch (parameter)
            {
                case null:
                    path += $"plumbing";
                    break;
                case string str when str == "Gender":
                    path += $"Gender/gender_{(int)value}";
                    break;
                case string str when str == "ToolBar":
                default:
                    path += $"ToolBar/{parameter.ToString().ToLower()}";
                    break;
            }
            path += ".png";

            if (!cache.ContainsKey(path))
            {
                cache.Add(path, new BitmapImage(new Uri(path, UriKind.Relative)));
            }

            return cache[path];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
