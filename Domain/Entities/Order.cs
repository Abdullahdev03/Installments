namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal Amount { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public Product Product { get; set; }
    public Customer Customer { get; set; }

    public Order(int id, DateTime orderDate, decimal amount, int productId, int customerId)
    {
        Id = id;
        OrderDate = orderDate;
        Amount = amount;
        ProductId = productId;
        CustomerId = customerId;
    }
}