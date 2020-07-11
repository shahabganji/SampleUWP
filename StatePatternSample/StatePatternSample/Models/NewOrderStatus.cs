namespace StatePatternSample.Models
{
    internal class NewOrderStatus : OrderStatus
    {
        public override bool CanTransitionTo(OrderStatus next)
            => next == Cancelled || next == Paid;

        public override void CancelOrder()
        {
            this.Context.ChangeStatusTo(Cancelled);
        }

        public override void Pay()
        {
            this.Context.ChangeStatusTo(Paid);
        }

        public override void ShipOrder()
        {
        }

        public override void Revise()
        {
        }

        public NewOrderStatus() : base(1, "New")
        {
        }
    }
}