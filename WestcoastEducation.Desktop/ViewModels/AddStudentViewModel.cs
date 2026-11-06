using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class AddStudentViewModel : ViewModelBase
{
    [ObservableProperty] public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty] public partial string LastName { get; set; } = string.Empty;
    [ObservableProperty] public partial int Phone { get; set; }
    [ObservableProperty] public partial string PersonalNumber { get; set; } = string.Empty;
    [ObservableProperty] public partial string Street { get; set; } = string.Empty;
    [ObservableProperty] public partial int ZipCode { get; set; }
    [ObservableProperty] public partial string City { get; set; } = string.Empty;

    private readonly IStudentService _studentService;

    public AddStudentViewModel(IStudentService studentService)
    {
        _studentService = studentService;
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
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ClearForm()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Phone = 0;
        PersonalNumber = string.Empty;
        Street = string.Empty;
        ZipCode = 0;
        City = string.Empty;
    }
}