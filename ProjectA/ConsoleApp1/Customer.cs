using FlowerShopDomain;

public class Customer : BaseEntity
{
    public string FullName { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public Order CreateOrder(Flower flower)
    {
        var order = new Order
        {
            Customer = this,
            Flower = flower,
            OrderDate = DateTime.Now,
            Status = OrderStatus.Pending
        };
        Orders.Add(order);
        return order;
    }
}