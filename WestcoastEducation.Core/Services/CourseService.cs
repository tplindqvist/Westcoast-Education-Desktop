using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class CourseService : ICourseService
{
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
}