namespace ProjectManagement.Domain.Entities;

public class Address
{
    public required string Line1 { get; set; }
    public string? Line2 { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string Country { get; set; }
    public required string PostCode { get; set; }

}
