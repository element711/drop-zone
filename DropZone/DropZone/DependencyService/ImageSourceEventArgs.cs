using System;
using DropZone.Annotations;
using Xamarin.Forms;

namespace DropZone.DependencyService
{
    /// <summary>
    /// The image source event args.
    /// </summary>
    public class ImageSourceEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSourceEventArgs"/> class.
        /// </summary>
        public ImageSourceEventArgs([NotNull] ImageSource imageSource)
        {
            if (imageSource == null) throw new ArgumentNullException("imageSource");

            ImageSource = imageSource;
        }

        /// <summary>
        /// The image source.
        /// </summary>
        public ImageSource ImageSource { get; private set; }
    }
}