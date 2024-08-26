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

    public string? QrUrl { get; set; }

    public string VCardToText()
    {
        return
            $"BEGIN:VCARD\r\n" +
            $"VERSION:3.0\r\n" +
            $"N:{LastName};{FirstName};;;\r\n" +
            $"FN:{FirstName} {LastName}\r\n" +
            $"EMAIL:{Email}\r\n" +
            $"TEL;TYPE={PhoneType.ToString().ToUpper()}:{PhoneNumber}\r\n" +
            $"ADR:;;{City};;{Country}\r\n" +
            $"END:VCARD\r\n";
    }

}


public enum PhoneType
{
    Mobile,
    Home,
    Work
}