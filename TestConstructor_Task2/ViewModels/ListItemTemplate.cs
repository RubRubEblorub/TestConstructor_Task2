using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace TestConstructor_Task2.ViewModels;

public class ListItemTemplate
{
    public Type ModelType { get; }
    public string Label { get; }
    public StreamGeometry ListItemIcon { get; }
    
    public ListItemTemplate(Type type, string iconKey)
    {
        ModelType = type;
        Label = type.Name.Replace("PageViewModel", string.Empty);
        
        Application.Current!.TryFindResource(iconKey, out var res);
        ListItemIcon = (StreamGeometry)res!;
    }
}