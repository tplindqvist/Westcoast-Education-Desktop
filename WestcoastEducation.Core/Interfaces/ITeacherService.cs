using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Interfaces;

public interface ITeacherService
{
    Task<List<Teacher>> LoadTeachers();
    Task AddTeacher(Teacher teacher);
    Task DeleteTeacher(string id);
}