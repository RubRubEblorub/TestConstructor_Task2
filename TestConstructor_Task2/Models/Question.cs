using System;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestConstructor_Task2.ViewModels;

namespace TestConstructor_Task2.Models;

public partial class Question : ObservableObject
{
    [ObservableProperty]
    private string _questionId;
    
    [ObservableProperty]
    private string _questionText;
    
    private bool _isChoosedCorrect;
    
    [ObservableProperty]
    [JsonIgnore]
    private Test _test;
    public ObservableCollection<AnswerOption> AnswerOptions { get; set; } = new();
    
    public Question(Test test)
    {
        _questionId = Guid.NewGuid().ToString();
        _test = test;
    }

    public Question()
    {
        
    }

    [RelayCommand]
    private void DeleteAnswerOption(AnswerOption answerOption)
    {
        AnswerOptions.Remove(answerOption);
    }
}