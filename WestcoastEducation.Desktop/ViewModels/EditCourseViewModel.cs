using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class EditCourseViewModel : ViewModelBase
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


    private readonly ICourseService _courseService;

    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;
    
    public EditCourseViewModel(ICourseService courseService,  IDialogService dialogService)
    {
        _courseService = courseService;
        _dialogService = dialogService;
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
        // Formuläret är tömt, inget att spara
        if (_id == string.Empty)
        {
            return;
        }
        
        // Fråga först, avbryt om svar är Nej
        var answer = await _dialogService.Confirm("Är du säker på att du vill spara ändringarna?");
        if (!answer)
        {
            return;
        }

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
            await _courseService.UpdateCourse(_id, course);
            ClearForm();
            await _dialogService.ShowMessage("Kursen uppdaterades!");
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
            _id = string.Empty;
        }
}