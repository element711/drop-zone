using System;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents the list of jumps on the main page..
    /// </summary>
    public class MainListPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainListPage"/> class.
        /// </summary>
        public MainListPage([NotNull] MainListPageViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException("viewModel");

            ConfigureViewModel(viewModel);
            ConfigureContent(viewModel);
            Appearing += (sender, args) => ConfigureToolbar(); // TODO: on android the toolbar has no buttons after adding a jump?
        }

        private void ConfigureViewModel(MainListPageViewModel viewModel)
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
        private void ConfigureContent(MainListPageViewModel viewModel)
        {
            SearchBar search = new SearchBar
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            search.TextChanged += (sender, args) => viewModel.Filter(args.NewTextValue);

            ListView listView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof (JumpCell))
            };
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
            ToolbarItems.Clear();
            ToolbarItems.Add(new ToolbarItem("Add Jump", string.Empty, AddJump));
            Title = "List";
        }

        private void AddJump()
        {
            ToolbarItems.Clear();
            Navigation.PushAsync(App.CreateJumpPage());
        }
    }
}
