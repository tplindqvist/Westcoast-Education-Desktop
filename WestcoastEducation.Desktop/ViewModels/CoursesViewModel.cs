using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class CoursesViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<Course> Courses { get; set; } = [];


    // Pratar bara med lagret under (CourseService), aldrig direkt med RestDB
    private readonly ICourseService _courseService;

    public CoursesViewModel(ICourseService courseService)
    {
        _courseService = courseService;
        Init();
    }

    private async void Init()
    {
        await LoadCourses();
    }

    private async Task LoadCourses()
    {
        IsLoading = true;
        try
        {
            // Be CourseService om kurserna
            var courses = await _courseService.LoadCourses();
            // Lägg dem i listan som vyn visar
            Courses = new ObservableCollection<Course>(courses);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task DeleteCourse(string id)
    {
        try
        {
            // Be CourseService ta bort kursen
            await _courseService.DeleteCourse(id);
            
            // Hämta listan på nytt
            await LoadCourses();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}