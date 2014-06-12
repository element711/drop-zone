using System;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.ViewModels;
using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// The tab page for the main page in the application.
    /// </summary>
    public class MainTabbedPage : TabbedPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainTabbedPage"/> class.
        /// </summary>
        public MainTabbedPage([NotNull] params Page[] pages)
        {
            if (pages == null) throw new ArgumentNullException("pages");

            Title = "Drop Zone";
            foreach (Page page in pages)
            {
                Children.Add(page);
            }

            Appearing += OnAppearing;
            Disappearing += OnDisappearing;
        }

        private async void OnAppearing(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem("Add Jump", string.Empty, AddJump));
            await RefreshTabs();
        }

        private async Task RefreshTabs()
        {
            foreach (Page page in Children)
            {
                IRefreshableViewModel viewModel = page.BindingContext as IRefreshableViewModel;
                if (viewModel != null)
                {
                    await viewModel.Refresh();
                }
            }
        }

        private void AddJump()
        {
            Navigation.PushAsync(App.CreateJumpPage());
        }

        private void OnDisappearing(object sender, EventArgs e)
        {
            ToolbarItems.Clear();            
        }
    }
}
