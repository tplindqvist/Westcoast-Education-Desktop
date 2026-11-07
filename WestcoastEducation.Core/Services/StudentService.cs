using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Core.Services;

public class StudentService : IStudentService
{
    private readonly IHttpService<Student> _httpService;

    public StudentService(IHttpService<Student> httpService)
    {
        _httpService = httpService;
    }

    public async Task<List<Student>> LoadStudents()
    {
        var students = await _httpService.Get("students");
        return students;
    }

    public async Task AddStudent(Student student)
    {
        await _httpService.Post("students", student);
    }

    public async Task DeleteStudent(string id)
    {
        await _httpService.Delete("students", id);
    }

    public async Task UpdateStudent(string id, Student student)
    {
        await _httpService.Put("students", id, student);
    }
}