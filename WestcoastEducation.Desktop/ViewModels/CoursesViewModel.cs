using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public class CoursesViewModel : ViewModelBase
{
    // Pratar bara med lagret under (CourseService), aldrig direkt med RestDB
    private readonly ICourseService _courseService;

    public CoursesViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }
}