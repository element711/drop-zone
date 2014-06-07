using Microsoft.Phone.Controls;
using Xamarin;
using Xamarin.Forms;


namespace DropZone.WinPhone
{
    /// <summary>
    /// The main page.
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            FormsMaps.Init();
            Content = DropZone.App.CreateMainPage().ConvertPageToUIElement(this);
        }
    }
}
