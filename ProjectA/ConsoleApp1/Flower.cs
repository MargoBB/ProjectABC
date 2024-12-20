using FlowerShopDomain;

public class Flower : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}