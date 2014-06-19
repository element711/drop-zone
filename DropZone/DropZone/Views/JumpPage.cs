using System;
using System.Collections.Generic;
using System.Linq;
using DropZone.Annotations;
using DropZone.DependencyService;
using DropZone.Models;
using DropZone.Repository;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents a jump page.
    /// </summary>
    public class JumpPage : XForms.Toolkit.Mvvm.BaseView
    {
        private readonly JumpViewModel _viewModel;
        private readonly IGalleryImageService _galleryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpPage"/> class.
        /// </summary>
        public JumpPage([NotNull] JumpViewModel viewModel, [NotNull] IRepository repository)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            if (repository == null) throw new ArgumentNullException("repository");

            _viewModel = viewModel;
            ConfigureToolbar();
            ConfigureContent(repository);
            ConfigureViewModel();
            _galleryService = Xamarin.Forms.DependencyService.Get<IGalleryImageService>();
            
            Appearing += OnAppearing;
            Disappearing += OnDisappearing;
        }

        private void ConfigureToolbar()
        {
            Title = "Add Jump";
        }

        private void OnAppearing(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem("Save", string.Empty, Save));
        }

        private void OnDisappearing(object sender, EventArgs e)
        {
            _galleryService.ImageSelected -= OnImageSelected;
            ToolbarItems.Clear();
        }

        private async void Save()
        {
            await _viewModel.Save();
        }

        private void ConfigureViewModel()
        {
            BindingContext = _viewModel;            
        }

        private void ConfigureContent(IRepository repository)
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
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
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
            
            Picker aircraftPicker = CreateAircraftPicker(repository);
            grid.Children.Add(aircraftPicker, 0, 3);

            Entry altitude = new Entry
            {
                Placeholder = "Altitude (ft)",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric
            };
            altitude.SetBinding(Entry.TextProperty, "Altitude");
            grid.Children.Add(altitude, 0, 4);

            Picker jumpTypePicker = CreateJumpTypePicker(repository);
            grid.Children.Add(jumpTypePicker, 0, 5);

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

            Entry description = new Entry
            {
                Placeholder = "Description",
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            description.SetBinding(Entry.TextProperty, "Description");
            grid.Children.Add(description, 0, 9);

            Button addImage = CreateAddImageButton();
            grid.Children.Add(addImage, 0, 10);

            Image image = new Image();
            image.SetBinding(Image.SourceProperty, "ThumbnailImage");          
            grid.Children.Add(image, 0, 11);
            
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

        private Button CreateAddImageButton()
        {
            Button addImage = new Button {Text = "Select Image"};

            addImage.Clicked += (sender, args) =>
            {
                _galleryService.ImageSelected += OnImageSelected;
                _galleryService.SelectImage();
            };
            return addImage;
        }

        private void OnImageSelected(object sender, ImageSourceEventArgs e)
        {
            _viewModel.UpdateImage(e.Image);
        }

        private Picker CreateAircraftPicker(IRepository repository)
        {
            IEnumerable<IAircraft> allAircraft = repository.LoadAllAircraft();
            Action<string> selectedIndexChangedAction = s =>
            {
                _viewModel.Aircraft = allAircraft.First(aircraft => aircraft.Name.Equals(s));
            };
            return CreatePicker("Aircraft", _viewModel.Aircraft.Name, selectedIndexChangedAction, allAircraft.Select(aircraft => aircraft.Name));
        }

        private Picker CreateJumpTypePicker(IRepository repository)
        {
            IEnumerable<IJumpType> allJumpTypes = repository.LoadAllJumpTypes();
            Action<string> selectedIndexChangedAction = s =>
            {
                _viewModel.JumpType = allJumpTypes.First(aircraft => aircraft.Name.Equals(s));
            };
            return CreatePicker("Jump Type", _viewModel.JumpType.Name, selectedIndexChangedAction, allJumpTypes.Select(aircraft => aircraft.Name));
        }

        // TODO: Change this to bind to view model. The Picker class is not yet bindable. 9/6/2014
        // http://forums.xamarin.com/discussion/17875/binding-to-picker-items
        private static Picker CreatePicker(string title, string selectedItem, Action<string> selectedIndexChangedAction, IEnumerable<string> items)
        {
            Picker picker = new Picker
            {
                Title = title, 
                VerticalOptions = LayoutOptions.Center
            };
            foreach (string item in items)
            {
                picker.Items.Add(item);
                if (item == selectedItem)
                {
                    picker.SelectedIndex = picker.Items.Count;
                }
            }
            picker.SelectedIndexChanged += (sender, args) => selectedIndexChangedAction.Invoke(picker.Items[picker.SelectedIndex]);
            return picker;
        }
    }
}
