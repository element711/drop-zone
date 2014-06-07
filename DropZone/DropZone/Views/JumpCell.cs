using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents a jump.
    /// </summary>
    public class JumpCell : ImageCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JumpCell"/> class.
        /// </summary>
        public JumpCell()
        {
            SetBinding(ImageSourceProperty, new Binding("ThumbnailImage"));
            SetBinding(TextProperty, new Binding("JumpNumber"));
            SetBinding(DetailProperty, new Binding("Description"));
        }
    }
}