namespace FlowerShopDomain
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public Flower Flower { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public void ApproveOrder()
        {
            throw new NotImplementedException();
        }

        public void CancelOrder()
        {
            throw new NotImplementedException();
        }
    }
}
