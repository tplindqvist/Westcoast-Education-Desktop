using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class CourseManager
{
    public List<Course> Courses { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<EducationManager> EducationManagers { get; set; }
    public List<Administrator> Administrators { get; set; }
    public CourseManager()
    {
        Courses = new List<Course>();
        Students = new List<Student>();
        Teachers = new List<Teacher>();
        EducationManagers = new List<EducationManager>();
        Administrators = new List<Administrator>();
    }

    public void AddCourse(Course course)
    {
        if (Courses.Contains(course))
        {
            Console.WriteLine("Kurs finns redan!");
        }
        else
        {
            Courses.Add(course);
        }
    }
    public void AddStudent(Student student)
    {
        if (Students.Contains(student))
        {
            Console.WriteLine("Student är redan tillsatt!");
        }
        else
        {
            Students.Add(student);
        }
    }

    public void AddTeacher(Teacher teacher)
    {
        if (Teachers.Contains(teacher))
        {
            Console.WriteLine("Lärare är redan tillsatt!");
        }
        else
        {
            Teachers.Add(teacher);
        }
    }

    public void AddEducationManager(EducationManager educationManager)
    {
        if (EducationManagers.Contains(educationManager))
        {
            Console.WriteLine("Utbildningsledare är redan tillsatt!");
        }
        else
        {
            EducationManagers.Add(educationManager);
        }
    }

    public void AddAdministrator(Administrator administrator)
    {
        if (Administrators.Contains(administrator))
        {
            Console.WriteLine("Admin är redan tillsatt!");
        }
        else
        {
            Administrators.Add(administrator);
        }
    }

    public void ListCourses()
    {
        foreach (Course course in Courses)
        {
            Console.WriteLine(course);
        }
    }
    public void ListStudents()
    {
        foreach (Student student in Students)
        {
            Console.WriteLine(student);
        }
    }

}
