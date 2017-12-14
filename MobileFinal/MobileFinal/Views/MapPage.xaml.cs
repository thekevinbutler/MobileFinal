using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MobileFinal.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            var initialMapLocation = MapSpan.FromCenterAndRadius(new Position(33.1227588, -117.1344643), Distance.FromMiles(2));

            MyMap.MoveToRegion(initialMapLocation);
        }
        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (MapPicker.SelectedIndex == 0)
            {
                MyMap.MapType = MapType.Street;
            }
            else if (MapPicker.SelectedIndex == 1)
            {
                MyMap.MapType = MapType.Satellite;
            }
            else if (MapPicker.SelectedIndex == 2)
            {
                MyMap.MapType = MapType.Hybrid;
            }
        }
    }
}
