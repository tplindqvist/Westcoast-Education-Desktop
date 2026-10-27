namespace WestcoastEducation.Core.Models;

public class Student : Person
{


    public Student
    (string firstName, string lastName, int phone, string personalNumber, string street, int zipCode, string city)
    : base
    (firstName, lastName, phone, personalNumber, street, zipCode, city){}

    public override string ToString()
    {
        return $"Student: {base.ToString()}";
    }


}
