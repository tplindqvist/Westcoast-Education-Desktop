using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
{
    [ObservableProperty] public partial string CourseNumber { get; set; } = string.Empty;
    [ObservableProperty] public partial string Title { get; set; } = string.Empty;
    [ObservableProperty] public partial int LengthInWeeks { get; set; }
    [ObservableProperty] public partial DateTime? StartDate { get; set; }
    [ObservableProperty] public partial DateTime? EndDate { get; set; }
    [ObservableProperty] public partial bool IsRemote { get; set; }

    // Sparar den nya kursen via CourseService, aldrig direkt mot RestDB
    private readonly ICourseService _courseService;


    public EditCourseViewModel(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // Id på kursen som ändras för Put
    private string _id = string.Empty;

    // Fyller formuläret med befintlig kurs
    public void Load(Course course)
    {
        _id = course.Id ?? string.Empty;
        CourseNumber = course.CourseNumber;
        Title = course.Title;
        LengthInWeeks = course.LengthInWeeks;
        StartDate = course.StartDate;
        EndDate = course.EndDate;
        IsRemote = course.CourseType == CourseType.Remote;
    }

    [RelayCommand]
    private async Task Save()
    {
        try
        {
            // 1. Kurstyp av kryssrutan
            CourseType type;
            if (IsRemote)
            {
                type = CourseType.Remote;
            }
            else
            {
                type = CourseType.Classroom;
            }

            // 2. Bygg kursen av fälten
            var course = new Course
            {
                CourseNumber = CourseNumber,
                Title = Title,
                LengthInWeeks = LengthInWeeks,
                StartDate = StartDate ?? DateTime.Today,
                EndDate = EndDate ?? DateTime.Today,
                CourseType = type
            };

            // 3. Spara via CourseService
            await _courseService.UpdateCourse(_id, course);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}