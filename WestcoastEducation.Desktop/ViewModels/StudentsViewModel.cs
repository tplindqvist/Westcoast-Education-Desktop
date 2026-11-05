using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<Student> Students { get; set; } = [];
    
    
    // Pratar bara med lagret under (StudentService), aldrig direkt med RestDB
    private readonly IStudentService _studentService;

    public StudentsViewModel(IStudentService studentService)
    {
        _studentService = studentService;
        Init();
    }

    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        try
        {
            // Be StudentService om kurserna
            var students = await _studentService.LoadStudents();
            // Lägg dem i listan som vyn visar
            Students = new ObservableCollection<Student>(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [RelayCommand]
    private async Task DeleteStudent(string id)
    {
        try
        {
            // Be StudentService ta bort kursen
            await _studentService.DeleteStudent(id);
            // Hämta listan på nytt
            await LoadStudents();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}