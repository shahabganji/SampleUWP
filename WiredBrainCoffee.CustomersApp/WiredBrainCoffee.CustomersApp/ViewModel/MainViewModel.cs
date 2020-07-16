using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WiredBrainCoffee.CustomersApp.Base;
using WiredBrainCoffee.CustomersApp.Commands;
using WiredBrainCoffee.CustomersApp.DataProvider;
using WiredBrainCoffee.CustomersApp.Model;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : Observable
    {
        private readonly ICustomerDataProvider _customerProvider;
        private readonly DelegateCommand<Customer> _deleteCustomerCommand;
        private Customer _selectedCustomer;

        public MainViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerProvider = customerDataProvider;
            Customers = new ObservableCollection<Customer>();

            _deleteCustomerCommand = new DelegateCommand<Customer>(OnDeleteCustomerExecute, OnDeleteCustomerCanExecute);
        }

        private void OnDeleteCustomerExecute(Customer customer)
        {
            if(!this.IsCustomerSelected) return;

            this.RemoveCustomer();
        }

        private bool OnDeleteCustomerCanExecute(Customer customer) => this.IsCustomerSelected;

        public ObservableCollection<Customer> Customers { get; }
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                if (_selectedCustomer == value) return; // this line prevents stack overflow from happening

                _selectedCustomer = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged(nameof(IsCustomerSelected));
                _deleteCustomerCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => this.SelectedCustomer != null;

        public async Task LoadAsync()
        {
            var customers = await _customerProvider.LoadCustomersAsync();

            foreach (var customer in customers)
            {
                this.Customers.Add(customer);
            }
        }
        public async Task SaveAsync()
        {
            var customers = this.Customers.OfType<Customer>();
            await _customerProvider.SaveCustomersAsync(customers);
        }
        
        public ICommand DeleteCustomerCommand => _deleteCustomerCommand;
        public void RemoveCustomer()
        {
            if( !this.IsCustomerSelected ) return;

            this.Customers.Remove(this.SelectedCustomer);
            this.SelectedCustomer = null;
        }

        public void AddNewCustomer()
        {
            var customer = new Customer { FirstName = "New" };
            this.Customers.Add(customer);
            this.SelectedCustomer = customer;
        }
    }
}