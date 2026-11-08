using System.Threading.Tasks;

namespace WestcoastEducation.Desktop.Interfaces;

public interface IDialogService
{
    Task<bool> Confirm(string message);
    Task ShowMessage(string message);
    Task ShowLoadError(); 
    Task ShowDeleteError();
}