using System;
using System.IO;
using DropZone.Annotations;

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
        public ImageSourceEventArgs([NotNull] Stream image)
        {
            if (image == null) throw new ArgumentNullException("image");

            Image = image;
        }

        /// <summary>
        /// The image source.
        /// </summary>
        public Stream Image { get; private set; }
    }
}