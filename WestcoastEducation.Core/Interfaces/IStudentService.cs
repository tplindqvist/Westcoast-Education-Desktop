using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Interfaces;

public interface IStudentService
{
    Task<List<Student>> LoadStudents();
    Task AddStudent(Student student);
    Task DeleteStudent(string id);
}