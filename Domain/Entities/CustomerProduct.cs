namespace Domain.Entities;

public class CustomerProduct
{

    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public CustomerProduct(int id, int productId, int customerId)
    {
        Id = id;
        ProductId = productId;
        CustomerId = customerId;
    }
}