using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Services.Maps;
using StatePatternSample.Annotations;
using StatePatternSample.Models;
using static StatePatternSample.Models.OrderStatus;

namespace StatePatternSample.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public sealed class OrderViewModel : ViewModel
    {
        private Order _order;

        public OrderViewModel(Order order)
        {
            _order = order;
        }

        public string OrderId => _order.Id.ToString();
        public OrderStatus Status => _order.OrderStatus;

        public void Pay()
        {
            _order.Pay();
            this.Notify(nameof(Status));
        }

        public void Ship()
        {
            _order.ShipOrder();
            this.Notify(nameof(this.Status));
        }

        public void NewOrder()
        {
            _order = new Order(New, "New Order");
            this.Notify(nameof(this.Status));
            this.Notify(nameof(OrderId));
        }

        public void CancelOrder()
        {
            _order.CancelOrder();
            this.Notify(nameof(this.Status));
        }

        public void Revise()
        {
            _order.ReviseOrder();
            this.Notify(nameof(this.Status));
        }

    }
}
