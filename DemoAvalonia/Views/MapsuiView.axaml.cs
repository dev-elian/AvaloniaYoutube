using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoAvalonia.Helpers;
using Mapsui.Styles;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace DemoAvalonia.Views;

public partial class MapsuiView : UserControl
{
    List<Coordinate> _coordinates = [
        new Coordinate(-67.750997, -20.227364),
        new Coordinate(-64.526198, -18.952416),
        new Coordinate(-64.526198, -20.946708),
        new Coordinate(-61.740773, -20.970922)
        ];

    public MapsuiView()
    {
        InitializeComponent();
        ShowMap();
    }

    void ShowMap()
    {
        //tile layer from openstreetmap
        mapControl.Map?.Layers.Add(Mapsui.Tiling.OpenStreetMap.CreateTileLayer());

        Color color = MapsuiUtils.HexToMapsuiColor("#FF0856");

        ICollection<IStyle> styles = [
            MapsuiUtils.GetRoundedLineStyle(14, Color.Black),
            MapsuiUtils.GetSquaredLineStyle(9, color, PenStyle.ShortDash),
         ];

        LineString lineString = MapsuiUtils.CreateLineString(_coordinates);
        mapControl.Map?.Layers.Add(MapsuiUtils.CreateLinestringLayer(lineString, "Line Layer", styles));

    }
}