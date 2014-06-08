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
        public MainTypePage()
        {
            //ConfigureViewModel(viewModel);
            ConfigureContent();
            ConfigureToolbar();
        }

        private void ConfigureToolbar()
        {
            Title = "Jump Types";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Xamarin.Forms.Label.set_Text(System.String)")]
        private void ConfigureContent()
        {
            Content = new Label{Text = "Jumps grouped by type"};
        }
    }
}