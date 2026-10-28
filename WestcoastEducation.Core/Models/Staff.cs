using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public abstract class Staff : Person // Gemensam basklass för all personal
{
    [JsonIgnore]
    public List<Course> Courses { get; set; } = new List<Course>();
    public List<string> Subjects { get; set; } = new List<string>();

}
