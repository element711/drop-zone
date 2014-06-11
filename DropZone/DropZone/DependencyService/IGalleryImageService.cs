using System;

namespace DropZone.DependencyService
{
    /// <summary>
    /// Responsible for selecting an image from the gallery.
    /// </summary>
    public interface IGalleryImageService
    {
        /// <summary>
        /// Selects the image from the gallery.
        /// </summary>
        void SelectImage();

        /// <summary>
        /// Occurs when an image is selected by the user.
        /// </summary>
        event EventHandler<ImageSourceEventArgs> ImageSelected;
    }
}
