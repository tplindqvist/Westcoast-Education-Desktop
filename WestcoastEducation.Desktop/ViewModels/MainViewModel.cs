using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // DI-maskinen, används för att skapa sidor tillsammans med deras beroenden
    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty] public partial ViewModelBase CurrentView { get; set; } = new HomeViewModel();

    [RelayCommand]
    private void GoToHome()
    {
        CurrentView = new HomeViewModel();
    }

    [RelayCommand]
    private void GoToCourses()
    {
        // DI skapar sidan och lämnar in ICourseService automatiskt
        CurrentView = _serviceProvider.GetRequiredService<CoursesViewModel>();
    }

    [RelayCommand]
    private void GoToAddCourse()
    {
        CurrentView = _serviceProvider.GetRequiredService<AddCourseViewModel>();
    }
    
    [RelayCommand]
    private void GoToStudents()
    {
        CurrentView = _serviceProvider.GetRequiredService<StudentsViewModel>();
    }
    [RelayCommand]
    private void GoToTeachers()
    {
        CurrentView = _serviceProvider.GetRequiredService<TeachersViewModel>();
    }
    [RelayCommand]
    private void GoToAddStudent()
    {
        CurrentView = _serviceProvider.GetRequiredService<AddStudentViewModel>();
    }
    [RelayCommand]
    private void GoToAddTeacher()
    {
        CurrentView = _serviceProvider.GetRequiredService<AddTeacherViewModel>();
    }
    [RelayCommand]
    private void GoToEditCourse(Course course)
    {
        // DI skapar ett nytt tomt forumlär
        var vm = _serviceProvider.GetRequiredService<EditCourseViewModel>();
        // fyll formulär med kursens värden
        vm.Load(course);
        // Visa sidan
        CurrentView = vm;
    }
}