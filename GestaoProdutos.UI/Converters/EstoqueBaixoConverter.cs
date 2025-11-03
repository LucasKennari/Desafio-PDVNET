using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GestaoProdutos.UI.Converters
{
    public class EstoqueBaixoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int quantidade && quantidade <= 5)
            {
                var cor = Brushes.Black;
                if (parameter != null)
                {
                    switch (parameter?.ToString()?.ToLower())
                    {
                        case "cellestoquebaixo": cor = Brushes.Red; break;
                        case "rowestoquebaixo": cor = new SolidColorBrush(Color.FromRgb(255, 160, 160)); break;
                        case "blue": cor = Brushes.Blue; break;
                    }
                }
                return quantidade <= 5 ? cor : Brushes.Transparent;
            };
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
