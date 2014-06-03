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
            MainViewModel viewModel = new MainViewModel();
            MainPage mainPage = new MainPage(viewModel);
            NavigationPage navigationPage = new NavigationPage(mainPage);
            
            return navigationPage;
        }
        
        /// <summary>
        /// Gets the add jump page.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static Page GetJumpPage()
        {
            Jump jump = new Jump
            {
                BindingContext = new JumpViewModel()
            };
            return jump;
        }
    }
}
