using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.Models;
using DropZone.Repository;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace DropZone.Views
{
    /// <summary>
    /// Map page showing the locations of all of your jumps.
    /// </summary>
    public class MainMapPage : XForms.Toolkit.Mvvm.BaseView
    {
        private Map _map;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMapPage"/> class.
        /// </summary>
        public MainMapPage([NotNull] IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            Icon = "map.png";
            ConfigureMapPins(repository);
            ConfigureContent();
            ConfigureToolbar();
        }

        private void ConfigureMapPins(IRepository repository)
        {
            Appearing += async (sender, args) =>
            {
                IsBusy = true;

                // TODO: Change this to bind to view model when we can bind to pins property. 
                IEnumerable<IJump> jumps = await repository.LoadAllJumps();
                PopulateMapWith(jumps);

                IsBusy = false;
            };
        }

        private async void PopulateMapWith(IEnumerable<IJump> jumps)
        {
            foreach (IJump jump in jumps)
            {
                IEnumerable<Position> positions = await TryLoadPositionsFor(jump);
                foreach (Position position in positions)
                {
                    _map.Pins.Add(new Pin
                    {
                        Position = position,
                        Address = jump.Location,
                        Label = jump.JumpNumber,
                        Type = PinType.Place
                    });
                }
            }
        }

        private static async Task<IEnumerable<Position>> TryLoadPositionsFor(IJump jump)
        {
            try
            {
                Geocoder geocoder = new Geocoder();
                return await geocoder.GetPositionsForAddressAsync(jump.Location);
            }
            catch (Exception) { }

            return new List<Position>();
        }


        private void ConfigureContent()
        {
            // TODO: Get current coordinates -> use that as centre position, not on Auckland
            Position centerPosition = new Position(-36.848461, 174.762183);
            Distance radius = Distance.FromKilometers(200);

            _map = new Map(MapSpan.FromCenterAndRadius(centerPosition, radius))
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsShowingUser = true
            };
            Content = _map;
        }

        private void ConfigureToolbar()
        {
            Title = "Map";
        }
    }
}