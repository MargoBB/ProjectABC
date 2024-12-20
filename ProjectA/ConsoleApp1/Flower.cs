namespace FlowerShopDomain
{
    public class Flower : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public void UpdatePrice(decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
