namespace WestcoastEducation.Core.Models;

public abstract class Person
{

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Phone { get; set; }
    public string PersonalNumber { get; set; } = string.Empty;
    public string Street { get; set; }  = string.Empty;
    public int ZipCode { get; set; }
    public string City { get; set; } = string.Empty;

}