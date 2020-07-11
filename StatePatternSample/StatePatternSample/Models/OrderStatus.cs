namespace StatePatternSample.Models
{
    public abstract class OrderStatus : Enumeration
    {
        public static readonly OrderStatus New = new NewOrderStatus();
        public static readonly OrderStatus Paid = new PaidOrderStatus();
        public static readonly OrderStatus Shipped = new ShippedOrderStatus();
        public static readonly OrderStatus Cancelled = new CancelledOrderStatus();

        protected Order Context;

        public void SetContext(Order context) => Context = context;

        public abstract bool CanTransitionTo(OrderStatus next);

        public abstract void CancelOrder();
        public abstract void Pay();
        public abstract void ShipOrder();
        public abstract void Revise();


        protected OrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}