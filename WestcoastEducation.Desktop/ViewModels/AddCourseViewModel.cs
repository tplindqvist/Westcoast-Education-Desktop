using WestcoastEducation.Core.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    // Sparar den nya kursen via CourseService, aldrig direkt mot RestDB
    private readonly ICourseService _courseService;

    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }
}