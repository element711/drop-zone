using System;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// List of all jumps grouped by jump type.
    /// </summary>
    public class MainTypePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainTypePage"/> class.
        /// </summary>
        public MainTypePage([NotNull] MainPageViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            ConfigureViewModel(viewModel);
            ConfigureContent(viewModel);
            ConfigureToolbar();
            Icon = "groupedlist.png";
        }

        private void ConfigureViewModel(MainPageViewModel viewModel)
        {
            BindingContext = viewModel;

            Appearing += async (sender, args) =>
            {
                IsBusy = true;
                await viewModel.OnLoad(Navigation);
                IsBusy = false;
            };
        }

        private void ConfigureContent(MainPageViewModel viewModel)
        {
            ListView listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof (JumpCell)),
                IsGroupingEnabled = true,
                GroupDisplayBinding = new Binding("JumpTypeName"),
            };
            listView.SetBinding(ListView.ItemsSourceProperty, "JumpsGroupedByType");
            listView.ItemSelected += (sender, args) => viewModel.ItemSelected((JumpViewModel) args.SelectedItem);
            Content = listView;
        }

        private void ConfigureToolbar()
        {
            Title = "Jump Types";
        }
    }
}