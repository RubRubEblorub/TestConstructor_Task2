using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestConstructor_Task2.ViewModels;

namespace TestConstructor_Task2.Models;

public partial class Test : ObservableObject
{
    private readonly int _testId;
    
    [ObservableProperty]
    private string _testResult;
    
    [ObservableProperty]
    private string _testName;
    public ObservableCollection<Question> Questions { get; set; } = [];
    
    public Test(int testId)
    {
        _testId = testId;
    }

    public Test()
    {
        
    }
    
    [RelayCommand]
    private void AddQuestion()
    {
        Questions.Add(new Question(new Test(_testId)) { QuestionText = $"Question {Questions.Count + 1}" });
    }
    
    [RelayCommand]
    private void AddAnswerOption(Question question)
    {
        if (question.QuestionText != null && question.AnswerOptions.Count < 4)
        {
            question.AnswerOptions.Add(new AnswerOption(question));
        }
    }

    [RelayCommand]
    private void DeleteQuestion(Question question)
    {
        Questions.Remove(question);
    }
    
    public (int countCorrect, int countTotal) CalculateTestResults()
    {
        int countCorrect = 0;
        int countTotal = Questions.Count;
        
        foreach (var question in Questions)
        {
            if (question.AnswerOptions.Any(e => e.IsCorrect && e.IsSelected))
            {
                countCorrect++;
            }
        }
        
        return (countCorrect, countTotal);
    }
}