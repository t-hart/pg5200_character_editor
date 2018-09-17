using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CharacterEditor.Model
{
        public class RaceToIndexConverter : IValueConverter
        {
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
                parameter is List<Race> l  && value is Race r? l.FindIndex(x => x == r) : -1;

            public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
                parameter is List<Race> l && value is int v ? l[v] : Race.Unset;
        }
}
