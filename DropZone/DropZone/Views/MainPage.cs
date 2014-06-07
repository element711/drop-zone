using System;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents the main page in the app.
    /// </summary>
    public class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage([NotNull] MainPageViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            ConfigureViewModel(viewModel);
            ConfigureToolbar();
            ConfigureContent(viewModel);
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Xamarin.Forms.Label.set_Text(System.String)")]
        private void ConfigureContent(MainPageViewModel viewModel)
        {
            SearchBar search = new SearchBar
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            // TODO: This filtering has bugs and I'm not sure why - come back and look at this (need second pair of eyes?).
            search.TextChanged += (sender, args) => viewModel.Filter(args.NewTextValue);

            ListView listView = new ListView { ItemTemplate = new DataTemplate(typeof (JumpCell)) };
            listView.SetBinding(ListView.ItemsSourceProperty, "Jumps");
            listView.ItemSelected += (sender, args) => viewModel.ItemSelected((JumpViewModel) args.SelectedItem);
            
            Content = new StackLayout
            {
                Children = 
                {
                    search,
                    listView
                }
            };
        }

        private void ConfigureToolbar()
        {
            ToolbarItems.Add(new ToolbarItem("Add Jump", string.Empty, AddJump));
            Title = "Drop Zone";
        }

        private void AddJump()
        {
            Navigation.PushAsync(App.GetJumpPage());
        }
    }
}
