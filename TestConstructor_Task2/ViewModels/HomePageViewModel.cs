using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestConstructor_Task2.ViewModels;

public partial class HomePageViewModel() : ViewModelBase
{
    [ObservableProperty]
    private MainWindowViewModel _mainWindowViewModel;
    
    [ObservableProperty]
    private bool _buttonsVisibility;

    public HomePageViewModel(MainWindowViewModel mainWindowViewModel) : this()
    {
        MainWindowViewModel = mainWindowViewModel;
        ButtonsVisibility = mainWindowViewModel.ButtonsVisibility;
    }
    
    [RelayCommand]
    private void OpenConstructor()
    {
        MainWindowViewModel.CurrentPage = new CreateTestPageViewModel();
        MainWindowViewModel.ButtonsVisibility = false;
    }

    [RelayCommand]
    private void OpenArchive()
    {
        MainWindowViewModel.CurrentPage = new ArchivePageViewModel();
        MainWindowViewModel.ButtonsVisibility = false;
    }
}