using System;
using System.IO;
using DropZone.DependencyService;
using DropZone.WinPhone;
using Microsoft.Phone.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(GalleryImageService_WinPhone))]
namespace DropZone.WinPhone
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class GalleryImageService_WinPhone : IGalleryImageService
    {
        /// <summary>
        /// Occurs when an image is selected by the user.
        /// </summary>
        public event EventHandler<ImageSourceEventArgs> ImageSelected;

        /// <summary>
        /// Selects the image from the gallery.
        /// </summary>
        public void SelectImage()
        {
            PhotoChooserTask photoTask = new PhotoChooserTask { ShowCamera = true };
            photoTask.Completed += (sender, result) =>
            {
                if (result.TaskResult == TaskResult.OK)
                {
                    OnImageSelected(result.ChosenPhoto);
                }
            };
            photoTask.Show();
        }

        private void OnImageSelected(Stream stream)
        {
            if (ImageSelected != null)
            {
                ImageSelected.Invoke(this, new ImageSourceEventArgs(stream));
            }
        }
    }
}