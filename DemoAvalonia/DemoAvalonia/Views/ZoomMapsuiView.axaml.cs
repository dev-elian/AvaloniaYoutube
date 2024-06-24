using Avalonia.Controls;
using Avalonia.Interactivity;
using DemoAvalonia.ViewModels;

namespace DemoAvalonia.Views;

public partial class ZoomMapsuiView : UserControl
{
    ZoomMapsuiViewModel vm = new();
    public ZoomMapsuiView()
    {
        InitializeComponent();
        DataContext = vm;
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        vm.RefreshMap += RefreshMap;
        vm.LoadExample();
    }

    protected override void OnUnloaded(RoutedEventArgs e)
    {
        vm.RefreshMap -= RefreshMap;
        base.OnUnloaded(e);
    }

    void RefreshMap()
    {
        mapControl.Map = ((ZoomMapsuiViewModel)DataContext).Map;
    }
}