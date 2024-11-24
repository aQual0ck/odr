using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace odr.Classes
{
    public class SupplierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var suppliers = value as ICollection<Supplier>;
            if (suppliers == null || !suppliers.Any())
            {
                return "отсутвуют";
            }

            return string.Join(", ", suppliers.Select(s => s.Title));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
