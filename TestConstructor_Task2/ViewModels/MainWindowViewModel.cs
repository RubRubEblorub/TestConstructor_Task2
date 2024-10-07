using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TestConstructor_Task2.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isPaneOpen;
    
    [ObservableProperty]
    private ViewModelBase _currentPage;

    [ObservableProperty] 
    private ListItemTemplate? _selectedListItem;
    
    [ObservableProperty]
    private bool _buttonsVisibility = true;

    public MainWindowViewModel()
    {
        CurrentPage = new HomePageViewModel(this);
    }
    
    [RelayCommand]
    private void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    
    partial void OnSelectedListItemChanged(ListItemTemplate? value)
    {
        if (value == null) return;
        
        var instance = Activator.CreateInstance(value.ModelType);
        if (instance == null) return;
        
        ButtonsVisibility = false;
        CurrentPage = (ViewModelBase)instance;
    }
    
    public ObservableCollection<ListItemTemplate> Items { get; } =
    [
        new ListItemTemplate(typeof(HomePageViewModel), "HomeRegular"),
        new ListItemTemplate(typeof(CreateTestPageViewModel), "CollectionsRegular"),
        new ListItemTemplate(typeof(ArchivePageViewModel), "OrganizationRegular"),
    ];
}