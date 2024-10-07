using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestConstructor_Task2.ViewModels;

namespace TestConstructor_Task2.Views;

public partial class ArchivePageView : UserControl
{
    public ArchivePageView()
    {
        InitializeComponent();
        
        DataContext = new ArchivePageViewModel();
    }
}