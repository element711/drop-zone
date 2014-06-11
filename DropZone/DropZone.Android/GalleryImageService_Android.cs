using System;
using Android.App;
using Android.Content;
using DropZone.DependencyService;
using DropZone.Droid;
using Xamarin.Forms;

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

            Intent imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            
            androidContext.ConfigureActivityResultCallback(ImageChooserCallback);
            androidContext.StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 0);           
        }

        private void ImageChooserCallback(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                if (ImageSelected != null)
                {
                    Android.Net.Uri uri = data.Data;
                    if (ImageSelected != null)
                    {
                        ImageSource imageSource = ImageSource.FromStream(() => Forms.Context.ContentResolver.OpenInputStream(uri));
                        ImageSelected.Invoke(this, new ImageSourceEventArgs(imageSource));
                    }
                }
            }
        }
    }
}