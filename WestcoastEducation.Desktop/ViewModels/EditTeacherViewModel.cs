using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestcoastEducation.Core.Interfaces;
using WestcoastEducation.Core.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WestcoastEducation.Desktop.Interfaces;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class EditTeacherViewModel : ViewModelBase
{
    [ObservableProperty] public partial string FirstName { get; set; } = string.Empty;
    [ObservableProperty] public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty] public partial string Phone { get; set; } = string.Empty;
    [ObservableProperty] public partial string PersonalNumber { get; set; } = string.Empty;
    [ObservableProperty] public partial string Street { get; set; } = string.Empty;

    [ObservableProperty] public partial string ZipCode { get; set; } = string.Empty;
    [ObservableProperty] public partial string City { get; set; } = string.Empty;

    // Kompetensområden läggs till i formuläret
    public ObservableCollection<string> Subjects { get; } = new();

    // Textrutan för ett nytt kompetensområde
    [ObservableProperty] public partial string NewSubject { get; set; } = string.Empty;

    private readonly ITeacherService _teacherService;

    // Visar dialogrutor utan ViewModelns vetskap
    private readonly IDialogService _dialogService;

    // Id på läraren som ändras för Put
    private string _id = string.Empty;

    public EditTeacherViewModel(ITeacherService teacherService, IDialogService dialogService)
    {
        _teacherService = teacherService;
        _dialogService = dialogService;
    }

    // Fyller formuläret med en befintlig lärare
    public void Load(Teacher teacher)
    {
        _id = teacher.Id ?? string.Empty;
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        Phone = teacher.Phone;
        PersonalNumber = teacher.PersonalNumber;
        Street = teacher.Street;
        ZipCode = teacher.ZipCode;
        City = teacher.City;

        // Lägg lärarens kompetenser i formulärets lista
        foreach (var subject in teacher.Subjects)
        {
            Subjects.Add(subject);
        }
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
            var teacher = new Teacher
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                PersonalNumber = PersonalNumber,
                Street = Street,
                ZipCode = ZipCode,
                City = City,
                Subjects = new List<string>(Subjects)
            };

            // Spara via TeacherService
            await _teacherService.UpdateTeacher(_id, teacher);

            ClearForm();
            await _dialogService.ShowMessage("Läraren uppdaterades!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await _dialogService.ShowMessage("Något gick fel, läraren sparades inte");
        }
    }

    // Lägger till det som står i textrutan som nytt kompetensområde
    [RelayCommand]
    private void AddSubject()
    {
        if (string.IsNullOrWhiteSpace(NewSubject))
        {
            return;
        }

        Subjects.Add(NewSubject.Trim());
        NewSubject = string.Empty;
    }

    [RelayCommand]
    private void RemoveSubject(string subject)
    {
        Subjects.Remove(subject);
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
        NewSubject = string.Empty;
        Subjects.Clear();
        _id = string.Empty;
    }
}