using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public class Course
{
    [JsonPropertyName("_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Id { get; set; }
    public string CourseNumber { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int LengthInWeeks { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public CourseType CourseType { get; set; }

    [JsonIgnore] // Bara kursens egna uppgifter ska med
    public Teacher? Teacher { get; set; } // Aggregation (läraren skapas någon annanstans, kursen pekar bara på den) 

    [JsonIgnore] public List<Student> Students { get; set; } = new List<Student>();

    public void AddStudent(Student student)
    {
        if (Students.Contains(student))
        {
            Console.WriteLine("Student finns redan i kursen.");
        }
        else
        {
            Students.Add(student);
        }
    }

    public void AssignTeacher(Teacher teacher)
    {
        Teacher = teacher;
        teacher.Courses.Add(this);
    }

    private string GetTeacherText()
    {
        if (Teacher == null)
        {
            return "Ingen lärare tillsatt";
        }
        else
        {
            return $"{Teacher.FirstName} {Teacher.LastName}";
        }
    }

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