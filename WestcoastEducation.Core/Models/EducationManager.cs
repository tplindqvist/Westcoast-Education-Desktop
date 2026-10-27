namespace WestcoastEducation.Core.Models;

public class EducationManager : Staff
{

    public DateOnly EmploymentDate { get; set; }

    public EducationManager
    (string firstName,
    string lastName,
    int phone,
    string personalNumber,
    string street,
    int zipCode,
    string city,
    string subject,
    DateOnly employmentDate)
    : base
    (firstName, lastName, phone, personalNumber, street, zipCode, city, subject)
    {
        EmploymentDate = employmentDate;
    }

    public override string ToString()
    {
        return $"Utbildningsledare: {base.ToString()} | Anställningsdatum: {EmploymentDate:yyyy-MM-dd}";
    }

}
