using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace WestcoastEducation.Desktop.Views;

public partial class DialogWindow : Window
{
    public DialogWindow()
    {
        InitializeComponent();
    }

    // Sätter texten. isQuestion = true ger ja/nej, false ger bara ok
    public DialogWindow(string message, bool isQuestion) : this()
    {
        MessageText.Text = message;
        YesButton.IsVisible = isQuestion;
        NoButton.IsVisible = isQuestion;
        OkButton.IsVisible = !isQuestion;
    }

    // Stänger fönstret och svarar true
    private void Yes_Click(object? sender, RoutedEventArgs e)
    {
        Close(true);
    }

    // Stänger fönstret och svarar false
    private void No_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}