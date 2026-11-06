using CommunityToolkit.Mvvm.ComponentModel;

namespace WestcoastEducation.Desktop.ViewModels;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial bool IsLoading { get; set; }
}