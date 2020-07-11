using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePatternSample.Models
{
    public class Order
    {
        public string Name { get; private set; }
        public int Id { get; set; }

        public OrderStatus OrderStatus { get; private set; }

        public Order(OrderStatus status, string name)
        {
            this.Name = name;
            this.Id = new Random().Next(1, 99999);
            this.ChangeStatusTo(status);
        }

        public void ChangeStatusTo(OrderStatus status)
        {
            this.OrderStatus = status;
            status.SetContext(this);
        }

        public void Pay() => this.OrderStatus.Pay();

        public void ShipOrder() => this.OrderStatus.ShipOrder();

        public void CancelOrder() => this.OrderStatus.CancelOrder();

        public void ReviseOrder() => this.OrderStatus.Revise();
    }
}