namespace WestcoastEducation.Core.Models;

public class Address
{
    public string Street { get; set; }
    public int ZipCode { get; set; }
    public string City { get; set; }

    public Address(
        string street, 
        int zipCode, 
        string city)
    {
        Street = street;
        ZipCode = zipCode;
        City = city;
    }

    public override string ToString()
    {
        return $"{Street}, {ZipCode} {City}";
    }

}