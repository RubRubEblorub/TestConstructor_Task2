using CommunityToolkit.Mvvm.ComponentModel;
using TestConstructor_Task2.Models;

namespace TestConstructor_Task2.ViewModels;

public partial class AnswerOption : ObservableObject
{
    [ObservableProperty]
    private string _optionText;
    
    [ObservableProperty]    
    private bool _isCorrect;
    
    [ObservableProperty]
    private bool _isSelected;
    
    [ObservableProperty]
    private Question _question;

    public AnswerOption(Question question)
    {
        _question = question;
    }

    public AnswerOption()
    {
        
    }
}