using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.Input;
using TestConstructor_Task2.Models;

namespace TestConstructor_Task2.ViewModels;

public partial class ArchivePageViewModel : ViewModelBase
{
    private static string _saveFilePath = Environment.CurrentDirectory + "\\DataBase.json";

    public ObservableCollection<Test> Tests { get; set; }
    
    public ArchivePageViewModel()
    {
        LoadTestList();
    }
    
    private void LoadTestList()
    {
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };
        
        var json = File.ReadAllText(_saveFilePath);
        Tests = JsonSerializer.Deserialize<ObservableCollection<Test>>(json, options);
    }

    [RelayCommand]
    private void PrintTestResults(Test test)
    {
        var (countCorrect, countTotal) = test.CalculateTestResults();
        
        float result = (float)countCorrect / countTotal * 100;

        test.TestResult = $"Result: {result}%\nCorrect answers: {countCorrect}/{countTotal}";
    }
}