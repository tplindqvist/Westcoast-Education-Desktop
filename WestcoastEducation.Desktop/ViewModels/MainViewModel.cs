using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    public partial ViewModelBase CurrentView { get; set; } = new HomeViewModel();

    [RelayCommand]
    private void GoToHome()
    {
        CurrentView =  new HomeViewModel();
    }

    [RelayCommand]
    private void GoToCourses()
    {
        CurrentView = new CoursesViewModel();
    }
}