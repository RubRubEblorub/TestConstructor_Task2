using Avalonia;
using System;
using System.IO;

namespace TestConstructor_Task2;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        string _saveFilePath = Environment.CurrentDirectory;
        string _fileName = "DataBase.json";

        if (!File.Exists(_saveFilePath))
        {
            File.Create(_saveFilePath).Dispose();
        }
        
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    } 
        
        

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}