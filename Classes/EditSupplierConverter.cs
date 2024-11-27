using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;

namespace odr.Classes
{
    public class EditSupplierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var suppliers = value as ICollection<Supplier>;
            if (suppliers == null || !suppliers.Any())
            {
                return null;
            }

            Run run = new Run($"\n{suppliers.Select(s => s.Title)}");
            Hyperlink hp = new Hyperlink(run);
            return string.Join("\n", hp);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
