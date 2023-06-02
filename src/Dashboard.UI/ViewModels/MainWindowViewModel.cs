using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dashboard.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "test";
    
    [RelayCommand]
    public void ButtonClicked() => Greeting = "Hello, Avalonia! 3";
}