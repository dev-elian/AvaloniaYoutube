using Mapsui;
using System;

namespace DemoAvalonia.ViewModels;

public partial class BaseMapViewModel:ViewModelBase
{
    public Action RefreshMap;
    Map _map = new();
    public Map Map
    {
        get => _map;
        set => SetProperty(ref _map, value);
    }

    public virtual void LoadExample()
    {

    }
}
