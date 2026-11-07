using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Interfaces;

public interface ICourseService
{
    Task<List<Course>> LoadCourses();
    Task AddCourse(Course course);
    Task DeleteCourse(string id);
    Task UpdateCourse(string id, Course course);
}