namespace FlowerShopDomain
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Order CreateOrder(Flower flower)
        {
            throw new NotImplementedException();
        }

        public bool CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
