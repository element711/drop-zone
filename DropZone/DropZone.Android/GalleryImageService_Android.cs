using System;
using Android.App;
using Android.Content;
using DropZone.DependencyService;
using DropZone.Droid;
using Xamarin.Forms;
using Xamarin.Media;

[assembly: Dependency(typeof(GalleryImageService_Android))]
namespace DropZone.Droid
{
    /// <summary>
    /// Responsible for loading images from the gallery on the Adroid platform.
    /// </summary>
    public class GalleryImageService_Android : Java.Lang.Object, IGalleryImageService
    {
        /// <summary>
        /// Occurs when an image is selected by the user.
        /// </summary>
        public event EventHandler<ImageSourceEventArgs> ImageSelected;

        /// <summary>
        /// Selects the image.
        /// </summary>
        public void SelectImage()
        {
            MainActivity androidContext = (MainActivity)Forms.Context;

            MediaPicker mediaPicker = new MediaPicker(androidContext);
            Intent pickPhotoIntent = mediaPicker.GetPickPhotoUI();
            androidContext.ConfigureActivityResultCallback(ImageChooserCallback);
            androidContext.StartActivityForResult(Intent.CreateChooser(pickPhotoIntent, "Select Photo"), 0);           
        }

        private async void ImageChooserCallback(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                MediaFile file = await data.GetMediaFileExtraAsync(Forms.Context);
                OnImageSelected(file);
            }
        }

        private void OnImageSelected(MediaFile file)
        {
            if (ImageSelected != null)
            {
                ImageSelected.Invoke(this, new ImageSourceEventArgs(file.GetStream()));
            }
        }
    }
}