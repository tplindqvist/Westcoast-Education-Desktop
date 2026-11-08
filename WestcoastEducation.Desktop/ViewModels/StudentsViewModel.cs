using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class StudentsViewModel : ViewModelBase
{
    [ObservableProperty] public partial ObservableCollection<Student> Students { get; set; } = [];


    // Pratar bara med lagret under (StudentService), aldrig direkt med RestDB
    private readonly IStudentService _studentService;

    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;

    public StudentsViewModel(IStudentService studentService, IDialogService dialogService)
    {
        _studentService = studentService;
        _dialogService = dialogService;
        Init();
    }

    private async void Init()
    {
        await LoadStudents();
    }

    private async Task LoadStudents()
    {
        IsLoading = true;
        try
        {
            // Be StudentService om studenterna
            var students = await _studentService.LoadStudents();
            // Lägg dem i listan som vyn visar
            Students = new ObservableCollection<Student>(students);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _dialogService.ShowLoadError();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private async Task DeleteStudent(string id)
    {
        var answer = await _dialogService.Confirm("Är du säker på att du vill radera studenten?");
        if (!answer)
        {
            return;
        }

        try
        {
            // Be StudentService ta bort studenten
            await _studentService.DeleteStudent(id);
            // Hämta listan på nytt
            await LoadStudents();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _dialogService.ShowDeleteError();
        }
    }
}