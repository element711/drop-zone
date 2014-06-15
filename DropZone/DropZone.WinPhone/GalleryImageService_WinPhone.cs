using System;
using DropZone.DependencyService;
using DropZone.WinPhone;
using Xamarin.Forms;

[assembly: Dependency(typeof(GalleryImageService_WinPhone))]
namespace DropZone.WinPhone
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class GalleryImageService_WinPhone : IGalleryImageService
    {
#pragma warning disable 0067
        /// <summary>
        /// Occurs when an image is selected by the user.
        /// </summary>
        public event EventHandler<ImageSourceEventArgs> ImageSelected;
#pragma warning restore 0067

        /// <summary>
        /// Selects the image from the gallery.
        /// </summary>
        public void SelectImage()
        {
            // TODO: Implement gallery selection on WP8
        }
    }
}