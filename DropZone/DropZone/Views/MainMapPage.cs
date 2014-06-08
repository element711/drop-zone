using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DropZone.Views
{
    /// <summary>
    /// Map page showing the locations of all of your jumps.
    /// </summary>
    public class MainMapPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMapPage"/> class.
        /// </summary>
        public MainMapPage()
        {
            //ConfigureViewModel(viewModel);
            ConfigureContent();
            ConfigureToolbar();
        }

        private void ConfigureToolbar()
        {
            Title = "Map";
        }

        private void ConfigureContent()
        {
            // TODO: Get current coordinates -> use that as centre position, not on Auckland
            Position centerPosition = new Position(-36.848461, 174.762183);
            Distance radius = Distance.FromKilometers(100);

            Content = new Map(MapSpan.FromCenterAndRadius(centerPosition, radius))
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }
    }
}