using System;
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
            Main mainPage = new Main { BindingContext = viewModel };
            mainPage.Appearing += mainPage_Appearing;
            return new NavigationPage(mainPage);
        }

        private static async void mainPage_Appearing(object sender, EventArgs e)
        {
            Main view = ((Main) sender);
            MainViewModel viewModel = ((MainViewModel) (view.BindingContext));

            view.IsBusy = true;
            await viewModel.OnLoad();
            view.IsBusy = false;
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
