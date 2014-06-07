using DropZone.Repository;
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
        private static FakeRepository _repository;

        private static FakeRepository Repository
        {
            get
            {
                if(_repository == null)
                {
                    _repository = new FakeRepository();
                }
                return _repository;
            }
        }

        /// <summary>
        /// Gets the main page which will be displayed across all devices.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static Page GetMainPage()
        {
            MainPageViewModel viewModel = new MainPageViewModel(Repository);
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
            JumpViewModel newJump = new JumpViewModel(Repository);
            return GetJumpPage(newJump);
        }

        /// <summary>
        /// Gets the jump page.
        /// </summary>
        public static Page GetJumpPage(JumpViewModel jump)
        {
            return new JumpPage(jump);
        }
    }
}
