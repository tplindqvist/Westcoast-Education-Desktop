using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public class Course
{
    // Id från RestDb (_id). Skickas inte med för nya kurser, RestDb skapar det
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }

    public string CourseNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int LengthInWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CourseType CourseType { get; set; }


    [JsonIgnore]
    public string CourseTypeText
    {
        get
        {
            if (CourseType == CourseType.Classroom)
            {
                return "Klassrum";
            }
            else
            {
                return "Distans";
            }
        }
    }
}