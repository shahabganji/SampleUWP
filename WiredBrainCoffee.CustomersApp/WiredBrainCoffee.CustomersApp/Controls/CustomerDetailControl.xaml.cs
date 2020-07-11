using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.Controls
{
    [ContentProperty(Name = nameof(Customer))]
    public sealed partial class CustomerDetailControl : UserControl
    {
        public static readonly DependencyProperty CustomerProperty =
            DependencyProperty.Register(nameof(Customer), typeof(Customer),
                typeof(CustomerDetailControl), new PropertyMetadata(null));

        public CustomerDetailControl()
        {
            this.InitializeComponent();
        }

        public Customer Customer
        {
            get => (Customer) this.GetValue(CustomerProperty);
            set => this.SetValue(CustomerProperty,
                value); 
            // no business logic should be implemented here, all should go for the callback of the PropertyMetaData in 
            // DependencyProperty.register method above.
        }
    }
}
