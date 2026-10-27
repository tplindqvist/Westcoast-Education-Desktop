namespace WestcoastEducation.Core.Models;

public class Teacher : Staff
{

    public Teacher
    (string firstName,
    string lastName,
    int phone,
    string personalNumber,
    string street,
    int zipCode,
    string city,
    string subject)
    : base
    (firstName, lastName, phone, personalNumber, street, zipCode, city, subject){}

    public override string ToString()
    {
        return $"Lärare: {base.ToString()}";
    }
}
