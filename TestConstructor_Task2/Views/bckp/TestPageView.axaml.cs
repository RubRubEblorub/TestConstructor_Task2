using Avalonia.Controls;
using TestConstructor_Task2.ViewModels;

namespace TestConstructor_Task2.Views;

public partial class TestPageView : UserControl
{
    public TestPageView()
    {
        InitializeComponent();
        
        DataContext = new TestPageViewModel();
    }
}