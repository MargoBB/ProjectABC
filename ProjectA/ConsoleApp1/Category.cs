using FlowerShopDomain;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Flower> Flowers { get; set; } = new List<Flower>();

    public void AddFlower(Flower flower)
    {
        if (flower != null && !Flowers.Contains(flower))
        {
            Flowers.Add(flower);
            flower.Category = this;
        }
    }

    public bool RemoveFlower(Flower flower)
    {
        if (Flowers.Contains(flower))
        {
            flower.Category = null;
            return Flowers.Remove(flower);
        }
        return false;
    }
}
