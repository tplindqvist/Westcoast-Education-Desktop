namespace WestcoastEducation.Core.Models;

public abstract class Staff : Person // Gemensam basklass för all personal
{
    public string Subject { get; set; }
    public List<Course> Courses { get; set; }
    public Staff
    (string firstName,
    string lastName,
    int phone,
    string personalNumber,
    string street,
    int zipCode,
    string city,
    string subject)
    : base
    (firstName, lastName, phone, personalNumber, street, zipCode, city)
    {
        Subject = subject;
        Courses = new List<Course>();
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Ämne: {Subject}";
    }

}
