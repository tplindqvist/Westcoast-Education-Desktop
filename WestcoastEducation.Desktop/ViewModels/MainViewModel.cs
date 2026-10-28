using CommunityToolkit.Mvvm.ComponentModel;

namespace WestcoastEducation.Desktop.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] 
    public partial ViewModelBase CurrentView { get; set; } = new HomeViewModel();
}