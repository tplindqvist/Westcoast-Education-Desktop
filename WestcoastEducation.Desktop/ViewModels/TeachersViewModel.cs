using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class TeachersViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<Teacher> Teachers { get; set; } = [];
    
    
    // Pratar bara med lagret under (TeacherService), aldrig direkt med RestDB
    private readonly ITeacherService _teacherService;
    
    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;

    public TeachersViewModel(ITeacherService teacherService,  IDialogService dialogService)
    {
        _teacherService = teacherService;
        _dialogService = dialogService;
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
        var answer = await _dialogService.Confirm("Är du säker på att du vill radera läraren?");
        if (!answer)
        {
            return;
        }
        
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
            await _dialogService.ShowMessage("Läraren kunde inte raderas");
        }
    }
}