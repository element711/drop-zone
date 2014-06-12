using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

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
        [JsonProperty(PropertyName = "containerName")]
        public string ContainerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "resourceName")]
        public string ResourceName { get; set; }

        /// <summary>
        /// Gets or sets the sas query string.
        /// </summary>
        [JsonProperty(PropertyName = "sasQueryString")]
        public string SasQueryString { get; set; }

        /// <summary>
        /// Gets or sets the image URI.
        /// </summary>
        [JsonProperty(PropertyName = "imageUri")]
        public string ImageUri { get; set; } 
    }
}