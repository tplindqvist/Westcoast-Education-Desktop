using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
    [ObservableProperty] 
    public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string LastName { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string Phone { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string PersonalNumber { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string Street { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string ZipCode { get; set; } = string.Empty;
    [ObservableProperty] 
    public partial string City { get; set; } = string.Empty;

    private readonly IStudentService _studentService;
    
    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;

    public AddStudentViewModel(IStudentService studentService, IDialogService dialogService)
    {
        _studentService = studentService;
        _dialogService = dialogService;
    }

    [RelayCommand]
    private async Task Save()
    {
        try
        {
            var student = new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                PersonalNumber = PersonalNumber,
                Street = Street,
                ZipCode = ZipCode,
                City = City
            };

            // Spara via StudentService
            await _studentService.AddStudent(student);
            ClearForm();
            await _dialogService.ShowMessage("Studenten sparades");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _dialogService.ShowMessage("Något gick fel, studenten sparades inte");
        }
    }

    private void ClearForm()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Phone = string.Empty;
        PersonalNumber = string.Empty;
        Street = string.Empty;
        ZipCode = string.Empty;
        City = string.Empty;
    }
}