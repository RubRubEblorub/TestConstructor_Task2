using Avalonia.Controls;
using TestConstructor_Task2.ViewModels;

namespace TestConstructor_Task2.Views;

public partial class CreateTestPageView : UserControl
{
    public CreateTestPageView()
    {
        InitializeComponent();
        
        DataContext = new CreateTestPageViewModel();
    }
}