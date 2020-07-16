using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DynamicSample.Common
{
    public sealed class DataTemplateLoader : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var name = item?.GetType().Name.Replace("ViewModel", "View");
            // ((container as ContentControl)?.Content as ViewModel)?
            //     .Name.Replace("ViewModel" , "View");

            if (name == null) return null;

            Application.Current.Resources.TryGetValue(name, out var template);

            return template as DataTemplate;
        }

    }
}
