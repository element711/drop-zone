using System;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents a jump page.
    /// </summary>
    public class JumpPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JumpPage"/> class.
        /// </summary>
        public JumpPage([NotNull] JumpViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            ConfigureViewModel(viewModel);
            ConfigureToolbar(viewModel);
            ConfigureContent();
        }

        private void ConfigureViewModel(JumpViewModel viewModel)
        {
            BindingContext = viewModel;            
        }

        private void ConfigureContent()
        {
            Grid grid = new Grid
            {
                Padding = new Thickness(20, 0, 20, 0),
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition{ Height = 300 }
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition{ Width= new GridLength(100, GridUnitType.Star) }
                },
            };
            Entry jumpNumber = new Entry
            {
                Placeholder = "Jump Number",
                HorizontalOptions= LayoutOptions.Fill,
                VerticalOptions= LayoutOptions.Fill,
            };
            jumpNumber.SetBinding(Entry.TextProperty, "JumpNumber");
            grid.Children.Add(jumpNumber, 0, 0);

            DatePicker datePicker = new DatePicker();
            datePicker.SetBinding(DatePicker.DateProperty, "JumpDate");
            grid.Children.Add(datePicker, 0, 1);

            Entry location = new Entry
            {
                Placeholder = "Location",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };
            location.SetBinding(Entry.TextProperty, "Location");
            grid.Children.Add(location, 0, 2);
            
            Entry aircraft = new Entry
            {
                Placeholder = "Aircraft",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };
            aircraft.SetBinding(Entry.TextProperty, "Aircraft");
            grid.Children.Add(aircraft, 0, 3);

            Entry altitude = new Entry
            {
                Placeholder = "Altitude (ft)",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric
            };
            altitude.SetBinding(Entry.TextProperty, "Altitude");
            grid.Children.Add(altitude, 0, 4);

            Entry manoeuvre = new Entry
            {
                Placeholder = "Manoeuvre",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };
            manoeuvre.SetBinding(Entry.TextProperty, "Manoeuvre");
            grid.Children.Add(manoeuvre, 0, 5);

            Entry freefallDelay = new Entry
            {
                Placeholder = "Freefall Delay (seconds)",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric
            };
            freefallDelay.SetBinding(Entry.TextProperty, "FreefallDelay");
            grid.Children.Add(freefallDelay, 0, 6);

            Entry totalTime = new Entry
            {
                Placeholder = "Total Time (seconds)",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric
            };
            totalTime.SetBinding(Entry.TextProperty, "TotalTime");
            grid.Children.Add(totalTime, 0, 7);

            Entry container = new Entry
            {
                Placeholder = "Container",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };
            container.SetBinding(Entry.TextProperty, "Container");
            grid.Children.Add(container, 0, 8);

            Editor description = new Editor
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            description.SetBinding(Editor.TextProperty, "Description");
            grid.Children.Add(description, 0, 9);

            ScrollView scrollView = new ScrollView
            {
                Content = new StackLayout
                {
                    Children =
                    {
                        grid
                    }
                }
            };

            Content = scrollView;
        }

        private void ConfigureToolbar(JumpViewModel viewModel)
        {
            Title = "Add Jump";
            Action save = async () => await Save(viewModel);
            ToolbarItems.Clear();
            ToolbarItems.Add(new ToolbarItem("Save", string.Empty, save));
        }

        private async Task Save(JumpViewModel viewModel)
        {
            await viewModel.Save();
            await Navigation.PopAsync();
        }
    }
}
