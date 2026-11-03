using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class CourseService : ICourseService
{
    // Levereras via DI, CourseService skapar den inte själv
    private readonly IHttpService<Course> _httpService;

    public CourseService(IHttpService<Course> httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<Course>> LoadCourses()
    {
        var courses = await _httpService.Get("courses");
        return courses;
    }

    public async Task AddCourse(Course course)
    {
       await _httpService.Post("courses", course);
    }

    public async Task DeleteCourse(string id)
    {
        await _httpService.Delete("courses", id);
    }
}