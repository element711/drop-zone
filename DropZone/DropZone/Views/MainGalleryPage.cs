using System;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// The gallery page on the main page.
    /// </summary>
    public class MainGalleryPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainGalleryPage"/> class.
        /// </summary>
        public MainGalleryPage([NotNull] MainGalleyPageViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");
            
            Title = "Gallery";
            ConfigureViewModel(viewModel);
            ConfigureContent();
        }

        private void ConfigureViewModel(MainGalleyPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Appearing += async (sender, args) =>
            {
                IsBusy = true;
                await viewModel.OnLoad();
                IsBusy = false;
            };
        }


        private void ConfigureContent()
        {
            Grid grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{Height = new GridLength(750)} // TODO: Height of auto doesn't show anything. Find out why and fix.
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10)
            };

            ListView leftListView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(GalleryItem)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasUnevenRows = true
            };
            ListView middleListView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(GalleryItem)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasUnevenRows = true,
            };
            ListView rightListView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(GalleryItem)),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HasUnevenRows = true
            };

            leftListView.SetBinding(ListView.ItemsSourceProperty, new Binding("LeftJumps"));
            middleListView.SetBinding(ListView.ItemsSourceProperty, new Binding("MiddleJumps"));
            rightListView.SetBinding(ListView.ItemsSourceProperty, new Binding("RightJumps"));

            grid.Children.Add(leftListView, 0, 0);
            grid.Children.Add(middleListView, 1, 0);
            grid.Children.Add(rightListView, 2, 0);
            
            Content = new ScrollView{Content = grid};
        }
    }
}
