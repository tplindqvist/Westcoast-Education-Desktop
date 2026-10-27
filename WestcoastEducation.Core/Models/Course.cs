using System.Text.Json.Serialization;

namespace WestcoastEducation.Core.Models;

public class Course
{
    public string CourseNumber { get; set; }
    public string Title { get; set; }
    public int LengthInWeeks { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public CourseType CourseType { get; set; }
    [JsonIgnore] // Bara kursens egna uppgifter ska med
    public Teacher? Teacher { get; set; } // Aggregation (läraren skapas någon annanstans, kursen pekar bara på den) 
    [JsonIgnore]
    public List<Student> Students { get; set; }
    public Course(
        string courseNumber,
        string title,
        int lengthInWeeks,
        DateOnly startDate,
        DateOnly endDate,
        CourseType courseType)
    {
        CourseNumber = courseNumber;
        Title = title;
        LengthInWeeks = lengthInWeeks;
        StartDate = startDate;
        EndDate = endDate;
        CourseType = courseType;
        Students = new List<Student>();
    }

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

    private string GetCourseTypeText()
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

    public override string ToString()
    {
        return $"Kurs: {Title} ({CourseNumber}), Längd: {LengthInWeeks} veckor, {StartDate:yyyy-MM-dd} - {EndDate:yyyy-MM-dd}, {GetCourseTypeText()}, Lärare: {GetTeacherText()}, {Students.Count} studenter";
    }

}
