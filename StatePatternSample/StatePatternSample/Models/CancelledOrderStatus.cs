namespace StatePatternSample.Models
{
    internal class CancelledOrderStatus : OrderStatus
    {
        public CancelledOrderStatus() : base(4, "Cancelled")
        {
        }

        public override bool CanTransitionTo(OrderStatus next) => next == New;

        public override void CancelOrder()
        {
        }

        public override void Pay()
        {
        }

        public override void ShipOrder()
        {
        }

        public override void Revise() => this.Context.ChangeStatusTo(new NewOrderStatus());
    }
}