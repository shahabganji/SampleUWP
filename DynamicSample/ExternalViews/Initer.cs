using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ExternalViews
{
    public static class Initer
    {
        public static void AddExternalViews(this Windows.UI.Xaml.Application application)
        {
            var resourceDictionary = new ResourceDictionary()
            {

            };

            // var resourceFile =  "ExternalViews/Views/ColleaguesView.xaml";
            // var colleagueResource = new Uri(resourceFile,UriKind.RelativeOrAbsolute);
            // Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary{Source = colleagueResource});
        }
    }

}
