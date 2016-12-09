using System;
using System.Configuration;
using ThinkGeo.MapSuite;
using ThinkGeo.MapSuite.Drawing;
using ThinkGeo.MapSuite.WinForms;

namespace WorldStreetsRenderLayerSample
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly string connection = ConfigurationManager.AppSettings["ConnectionString"];

        public Form()
        {
            InitializeComponent();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            winformsMap.MapUnit = GeographyUnit.Meter;
            winformsMap.BackgroundOverlay.BackgroundBrush = new GeoSolidBrush(GeoColor.SimpleColors.Red);

            LayerOverlay layerOverlay = new LayerOverlay();
            OsmWorldMapKitLayer osmWorldMapKitLayer = new OsmWorldMapKitLayer(connection);
            layerOverlay.Layers.Add(osmWorldMapKitLayer);
            winformsMap.Overlays.Add(layerOverlay);

            osmWorldMapKitLayer.Open();
            winformsMap.CurrentExtent = osmWorldMapKitLayer.Layers["osm_road_linestring"].GetBoundingBox();
            winformsMap.Refresh();
        }
    }
}