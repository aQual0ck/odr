using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace odr.Classes
{
    public class MaterialConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var materials = value as ICollection<Material>;
            if (materials == null || !materials.Any())
            {
                return "отсутвуют";
            }

            return string.Join(", ", materials.Select(s => s.Title));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
