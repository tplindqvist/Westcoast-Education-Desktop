namespace WestcoastEducation.Core.Models;

public abstract class Staff : Person // Gemensam basklass för all personal
{
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<string> Subjects { get; set; } = new List<string>();

}
