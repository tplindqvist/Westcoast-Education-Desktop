namespace WestcoastEducation.Core.Models;

public class Administrator : Staff
{
    // Anställningsdatum ligger här och i EducationManager, men inte i Staff eftersom lärare inte har något
    public DateOnly EmploymentDate { get; set; }
}
