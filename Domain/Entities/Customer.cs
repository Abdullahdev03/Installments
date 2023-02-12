namespace Domain.Entities;

public class Customer
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public ICollection<CustomerProduct> CustomerProducts { get; set; }


    public Customer(int id, string name, string phoneNumber, string email)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}