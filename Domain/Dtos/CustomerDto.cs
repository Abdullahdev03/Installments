using Domain.Entities;

namespace Domain.Dtos;

public class CustomerDto
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

}