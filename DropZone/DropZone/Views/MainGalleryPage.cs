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
        public MainGalleryPage()
        {
            Title = "Gallery";
            ConfigureContent();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Xamarin.Forms.Label.set_Text(System.String)")]
        private void ConfigureContent()
        {
            Label label = new Label{Text = "Gallery Page"};

            Content = new StackLayout
            {
                Children = { label }
            };
        }
    }
}
