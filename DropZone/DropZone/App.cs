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
            get { return _repository ?? (_repository = new FakeRepository()); }
        }

        /// <summary>
        /// Creates the main page.
        /// </summary>
        public static Page CreateMainPage()
        {
            MainListPage list = new MainListPage(new MainListPageViewModel(Repository));
            MainGalleryPage gallery = new MainGalleryPage(new MainGalleyPageViewModel(Repository));

            MainTabbedPage mainTabbedPage = new MainTabbedPage(list, gallery);

            return new NavigationPage(mainTabbedPage);
        }

        /// <summary>
        /// Creates the add jump page.
        /// </summary>
        public static Page CreateJumpPage()
        {
            JumpViewModel newJump = new JumpViewModel(Repository);
            return CreateJumpPage(newJump);
        }

        /// <summary>
        /// Creates the jump page.
        /// </summary>
        public static Page CreateJumpPage(JumpViewModel jump)
        {
            return new JumpPage(jump, Repository);
        }
    }
}
