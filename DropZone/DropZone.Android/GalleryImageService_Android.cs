using System;
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
        /// Selects the image.
        /// </summary>
        public Uri SelectImage()
        {
            Context androidContext = Forms.Context;

            Intent imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            
            androidContext.StartActivity(Intent.CreateChooser(imageIntent, "Select photo"));

            return null;
        }
    }
}