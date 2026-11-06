using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class TeacherService : ITeacherService
{
    private readonly IHttpService<Teacher> _httpService;

    public TeacherService(IHttpService<Teacher> httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<Teacher>> LoadTeachers()
    {
        var teachers = await _httpService.Get("teachers");
        return teachers;
    }

    public async Task AddTeacher(Teacher teacher)
    {
        await _httpService.Post("teachers", teacher);
    }

    public async Task DeleteTeacher(string id)
    {
        await _httpService.Delete("teachers", id);
    }
}