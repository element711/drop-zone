using System;
using DropZone.Annotations;
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

        private void OnAppearing(object sender, EventArgs e)
        {
            ToolbarItems.Add(new ToolbarItem("Add Jump", string.Empty, AddJump));
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
