namespace StatePatternSample.Models
{
    internal class PaidOrderStatus : OrderStatus
    {
        public PaidOrderStatus() : base(2, "Paid")
        {
        }

        public override bool CanTransitionTo(OrderStatus next)
            => next == Cancelled || next == Shipped;

        public override void CancelOrder()
        {
            this.Context.ChangeStatusTo(Cancelled);
        }

        public override void Pay()
        {
        }

        public override void ShipOrder()
        {
            this.Context.ChangeStatusTo(Shipped);
        }

        public override void Revise()
        {
        }
    }
}