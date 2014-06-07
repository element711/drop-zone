using Xamarin.Forms;

namespace DropZone.Views
{
    /// <summary>
    /// Represents a jump gallery item.
    /// </summary>
    public class GalleryItem : ViewCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GalleryItem"/> class.
        /// </summary>
        public GalleryItem()
        {
            Image image = new Image
            {
                Aspect = Aspect.AspectFill,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            image.SetBinding(Image.SourceProperty, new Binding("ThumbnailImage"));
            View = image;
        }
    }
}