namespace VCardGenerate.Models;

public class VCard
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}


public enum PhoneType
{
    Mobile,
    Home,
    Work
}