using Avalonia.Controls;
using Avalonia.Interactivity;
using DemoMapsui.ViewModels;

namespace DemoMapsui.Views;

public partial class LinesMapsuiView : UserControl
{
    LinesMapsuiViewModel vm = new();
    public LinesMapsuiView()
    {
        InitializeComponent();
        DataContext = vm;
        mapControl.Map = ((LinesMapsuiViewModel)DataContext).Map;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        vm.LoadExample();
    }
}