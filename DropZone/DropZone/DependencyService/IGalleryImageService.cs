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
        Uri SelectImage();
    }
}
