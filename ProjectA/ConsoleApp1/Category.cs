namespace FlowerShopDomain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Flower> Flowers { get; set; } = new List<Flower>();

        public void AddFlower(Flower flower)
        {
            throw new NotImplementedException();
        }

        public bool RemoveFlower(Flower flower)
        {
            throw new NotImplementedException();
        }
    }
}
