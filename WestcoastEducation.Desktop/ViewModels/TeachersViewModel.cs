using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<Teacher> Teachers { get; set; } = [];
    
    
    // Pratar bara med lagret under (TeacherService), aldrig direkt med RestDB
    private readonly ITeacherService _teacherService;

    public TeachersViewModel(ITeacherService teacherService)
    {
        _teacherService = teacherService;
        Init();
    }

    private async void Init()
    {
        await LoadTeachers();
    }

    private async Task LoadTeachers()
    {
        IsLoading = true;
        try
        {
            // Be TeacherService om lärarna
            var teachers = await _teacherService.LoadTeachers();
            // Lägg dem i listan som vyn visar
            Teachers = new ObservableCollection<Teacher>(teachers);
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
    private async Task DeleteTeacher(string id)
    {
        try
        {
            // Be TeacherService ta bort lärare
            await _teacherService.DeleteTeacher(id);
            // Hämta listan på nytt
            await LoadTeachers();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}