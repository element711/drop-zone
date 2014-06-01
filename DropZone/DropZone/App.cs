using DropZone.ViewModels;
using DropZone.Views;
using Xamarin.Forms;

namespace DropZone
{
    /// <summary>
    /// The skydive dropzone application.
    /// </summary>
    public class App
    {
        /// <summary>
        /// Gets the main page which will be displayed across all devices.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static Page GetMainPage()
        {
            LogEntry logEntry = new LogEntry
            {
                BindingContext = new LogEntryViewModel()
            };
            return logEntry;
        }
    }
}
