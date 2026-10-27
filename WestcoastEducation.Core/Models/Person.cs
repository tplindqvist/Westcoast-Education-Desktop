namespace WestcoastEducation.Core.Models;

public abstract class Person
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Phone { get; set; }
    public string PersonalNumber { get; set; }
    public Address Address { get; set; }


    public Person(
        string firstName, 
        string lastName, 
        int phone, 
        string personalNumber, 
        string street, 
        int zipCode, 
        string city)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        PersonalNumber = personalNumber;
        Address = new Address(street, zipCode, city); // Composition (Adressen skapas här inne och tillhör personen)
    }

    public override string ToString()
    {

        return $"{FirstName} {LastName}, {Phone}, {PersonalNumber}, {Address}";

    }

}