using FlowerShopDomain;

public class Order : BaseEntity
{
    public Customer Customer { get; set; }
    public Flower Flower { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }

    public void ApproveOrder()
    {
        Status = OrderStatus.Completed;
    }

    public void CancelOrder()
    {
        Status = OrderStatus.Canceled;
    }
}