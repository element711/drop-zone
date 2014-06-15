using System;
using DropZone.DependencyService;
using DropZone.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(GalleryImageService_iOS))]
namespace DropZone.iOS
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class GalleryImageService_iOS : IGalleryImageService
    {
        public event EventHandler<ImageSourceEventArgs> ImageSelected;

        public void SelectImage()
        {
            // TODO: Implement gallery selection on iOS
        }
    }
}