using Microsoft.WindowsAzure.Mobile.Service;

namespace MobileServices.DataObjects
{
    /// <summary>
    /// The to-do item.
    /// </summary>
    public class JumpItem : EntityData
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [complete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [complete]; otherwise, <c>false</c>.
        /// </value>
        public bool Complete { get; set; }

        /// <summary>
        /// Gets or sets the name of the container.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "container")]
        public string containerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "resource")]
        public string resourceName { get; set; }

        /// <summary>
        /// Gets or sets the sas query string.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "sas"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "sas")]
        public string sasQueryString { get; set; }

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "image"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
        public string imageUri { get; set; } 
    }
}