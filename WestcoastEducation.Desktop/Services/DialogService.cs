using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using WestcoastEducation.Desktop.Interfaces;
using WestcoastEducation.Desktop.Views;

namespace WestcoastEducation.Desktop.Services;

public class DialogService : IDialogService
{
    // Visar Ja/Nej och inväntar svar
    public async Task<bool> Confirm(string message)
    {
        var dialog = new DialogWindow(message, true);
        return await dialog.ShowDialog<bool>(GetMainWindow());
    }

    // Visar bara ok och väntar på att stängas
    public async Task ShowMessage(string message)
    {
        var dialog = new DialogWindow(message, false);
        await dialog.ShowDialog<bool>(GetMainWindow());
    }
    
    // Hämtar huvudfönstret, rutan ska ligga ovanpå
    private Window GetMainWindow()
    {
        var desktop = (IClassicDesktopStyleApplicationLifetime)Application.Current!.ApplicationLifetime!;
        return desktop.MainWindow!;
    }
}