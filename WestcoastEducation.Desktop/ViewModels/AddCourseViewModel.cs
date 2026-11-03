using System;
using CommunityToolkit.Mvvm.ComponentModel;
using WestcoastEducation.Core.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    [ObservableProperty] public partial string CourseNumber { get; set; } = string.Empty;
    [ObservableProperty] public partial string Title { get; set; } = string.Empty;
    [ObservableProperty] public partial int LengthInWeeks { get; set; }
    [ObservableProperty] public partial DateTime? StartDate { get; set; }
    [ObservableProperty] public partial DateTime? EndDate { get; set; }
    [ObservableProperty] public partial bool IsRemote { get; set; }

    // Sparar den nya kursen via CourseService, aldrig direkt mot RestDB
    private readonly ICourseService _courseService;


    public AddCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }
}