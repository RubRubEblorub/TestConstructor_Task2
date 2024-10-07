using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestConstructor_Task2.Models;

namespace TestConstructor_Task2.ViewModels;

public partial class CreateTestPageViewModel : ViewModelBase
{
    JsonSerializerOptions options = new()
    {
        ReferenceHandler = ReferenceHandler.Preserve
    };
    
    private static string _saveFilePath = Environment.CurrentDirectory + "\\DataBase.json";

    [ObservableProperty]
    private bool _saveButtonIsVisible;
    
    public ObservableCollection<Test> Tests { get; set; } = [];
    
    [RelayCommand]
    private void CreateTest()
    {
        Tests.Add(new Test(Tests.Count + 1));
        SaveButtonIsVisible = true;
    }
    
    [RelayCommand]
    private void SaveTest()
    {
        var json = File.ReadAllText(_saveFilePath);
        
        if (json != string.Empty)
        {
            var jsonTests = JsonSerializer.Deserialize<List<Test>>(json, options);

            foreach (var test in Tests)
            {
                jsonTests.Add(test);
            }
            
            File.WriteAllText(_saveFilePath, JsonSerializer.Serialize(jsonTests, options));
        }
        else
        {
            File.WriteAllText(_saveFilePath, JsonSerializer.Serialize(Tests, options));
        }
        
        Tests.Clear();
        SaveButtonIsVisible = false;
    }
}