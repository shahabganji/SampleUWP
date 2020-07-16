namespace StatePatternSample.Models
{
    internal class ShippedOrderStatus : OrderStatus
    {
        public ShippedOrderStatus() : base(3, "Shipped")
        {
        }

        public override bool CanTransitionTo(OrderStatus next) => false;

        public override void CancelOrder()
        {
        }

        public override void Pay()
        {
        }

        public override void ShipOrder()
        {
        }

        public override void Revise()
        {
        }
    }
}