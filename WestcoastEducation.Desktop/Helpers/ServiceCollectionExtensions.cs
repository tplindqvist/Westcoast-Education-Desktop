using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Core.Services;
using WestcoastEducation.Desktop.ViewModels;

namespace WestcoastEducation.Desktop.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainViewModel>();
        collection.AddSingleton<ICourseService, CourseService>();
        collection.AddSingleton<IHttpService<Course>, HttpService<Course>>();
        collection.AddTransient<CoursesViewModel>(); // Transient: ny sida varje gång, så att listan hämtas på nytt
        collection.AddTransient<AddCourseViewModel>();
        collection.AddSingleton<IStudentService, StudentService>();
        collection.AddSingleton<IHttpService<Student>, HttpService<Student>>();
    }
}