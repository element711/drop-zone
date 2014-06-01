using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// The main page of the Drop Zone application.
    /// </summary>
    public partial class Main : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            ToolbarItems.Add(new ToolbarItem("Add Jump", string.Empty, AddJump));
        }

        private void AddJump()
        {
            Navigation.PushAsync(App.GetJumpPage());
        }
    }
}
