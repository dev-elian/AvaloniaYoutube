using Avalonia.Controls;
using DemoAvalonia.Helpers;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Nts.Extensions;
using Mapsui.Projections;
using Mapsui.Styles;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Linq;

namespace DemoAvalonia.Views;

public partial class MainView : UserControl
{
    List<Coordinate> _coordinates = [
        new Coordinate(-67.750997, -20.227364),
        new Coordinate(-64.526198, -18.952416),
        new Coordinate(-64.526198, -20.946708),
        new Coordinate(-61.740773, -20.970922)
        ];

    public MainView()
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
