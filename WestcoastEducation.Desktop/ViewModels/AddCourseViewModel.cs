using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class AddCourseViewModel : ViewModelBase
{
    [ObservableProperty] 
    public partial string CourseNumber { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string Title { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial int? LengthInWeeks { get; set; }
    [ObservableProperty] 
    public partial DateTime? StartDate { get; set; }
    [ObservableProperty] 
    public partial DateTime? EndDate { get; set; }
    [ObservableProperty] 
    public partial bool IsRemote { get; set; }

    // Sparar den nya kursen via CourseService, aldrig direkt mot RestDB
    private readonly ICourseService _courseService;
    
    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;


    public AddCourseViewModel(ICourseService courseService, IDialogService dialogService)
    {
        _courseService = courseService;
        _dialogService =  dialogService;
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
                LengthInWeeks = LengthInWeeks ?? 0,
                StartDate = StartDate ?? DateTime.Today,
                EndDate = EndDate ?? DateTime.Today,
                CourseType = type
            };

            // 3. Spara via CourseService
            await _courseService.AddCourse(course);
            ClearForm();
            await _dialogService.ShowMessage("Kursen sparades!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _dialogService.ShowMessage("Något gick fel, kursen sparades inte!");
        }
    }

    private void ClearForm()
    {
        CourseNumber = string.Empty;
        Title = string.Empty;
        LengthInWeeks = null;
        StartDate = null;
        EndDate = null;
        IsRemote = false;
    }
}