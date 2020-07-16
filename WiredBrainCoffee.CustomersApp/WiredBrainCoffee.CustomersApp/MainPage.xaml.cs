using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.Linq;
using System.Numerics;
using Windows.ApplicationModel.Activation;
using Windows.System;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;
using WiredBrainCoffee.CustomersApp.ViewModel;


namespace WiredBrainCoffee.CustomersApp
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; private set; }

        public MainPage()
        {
            this.InitializeComponent();

            // enables caching of this page when navigating between pages.
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            AddKeyboardAccelerators();

            ViewModel = new MainViewModel(new CustomerDataProvider());
            this.DataContext = ViewModel;

            this.Loaded += MainPage_Loaded;

            Application.Current.Suspending += async (sender, args) =>
            {
                var deferral = args.SuspendingOperation.GetDeferral();

                await this.ViewModel.SaveAsync();

                deferral.Complete();
            };

            this.RequestedTheme = Application.Current.RequestedTheme == ApplicationTheme.Dark
                ? ElementTheme.Dark
                : ElementTheme.Light;
        }

        private void AddKeyboardAccelerators()
        {
            var altRight = new KeyboardAccelerator {Key = VirtualKey.Right, Modifiers = VirtualKeyModifiers.Menu};
            altRight.Invoked += OnHandler;

            var altLeft = new KeyboardAccelerator {Key = VirtualKey.Left, Modifiers = VirtualKeyModifiers.Menu};
            altLeft.Invoked += OnHandler;

            var altT = new KeyboardAccelerator {Key = VirtualKey.T, Modifiers = VirtualKeyModifiers.Menu};
            altT.Invoked += (_, __) => this.ToggleTheme_Click(null, null);

            void OnHandler(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
            {
                var column = Grid.GetColumn(this.CustomerListGrid);
                if (
                    (column == 0 && args.KeyboardAccelerator.Key == VirtualKey.Right)
                    ||
                    (column == 2 && args.KeyboardAccelerator.Key == VirtualKey.Left)
                )
                    this.ButtonMove_Click(sender, null);

                args.Handled = true;
            }


            this.KeyboardAccelerators.Add(altT);
            this.KeyboardAccelerators.Add(altRight);
            this.KeyboardAccelerators.Add(altLeft);
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await this.ViewModel.LoadAsync();
        }


        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            int column = Grid.GetColumn(this.CustomerListGrid); // Get Attached Property
            int newColumn = column == 0 ? 2 : 0;

            Grid.SetColumn(this.CustomerListGrid, newColumn); // Set Attached property
            this.MoveSymbolIcon.Icon = new SymbolIcon(newColumn == 0 ? Symbol.Forward : Symbol.Back);
        }

        private void ToggleTheme_Click(object sender, RoutedEventArgs e)
        {
            this.RequestedTheme =
                this.RequestedTheme == ElementTheme.Dark
                    ? ElementTheme.Light
                    : ElementTheme.Dark;
        }
    }
}