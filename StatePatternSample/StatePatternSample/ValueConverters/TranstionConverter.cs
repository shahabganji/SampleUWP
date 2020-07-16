using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using StatePatternSample.Models;
using static StatePatternSample.Models.Enumeration;

namespace StatePatternSample.ValueConverters
{
   public  class TransitionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is OrderStatus currentStatus)) return false;
            var nextStatus = FromDisplayName<OrderStatus>(parameter.ToString());

            return nextStatus != null && currentStatus.CanTransitionTo(nextStatus);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
