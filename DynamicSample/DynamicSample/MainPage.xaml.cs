using Windows.UI.Xaml.Controls;
using Common;
using DynamicSample.Common.ViewModels;


namespace DynamicSample
{
    public sealed partial class MainPage : Page
    {
        public ViewModel ViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

            var mainViewModel=  new MainViewModel();
            this.ViewModel = mainViewModel;

            // // If this is set, then Content={Binding} can be used in the view
            // DataContext = mainViewModel;

            this.Loaded += (sender, args) => mainViewModel.Load();
        }
    }
}
