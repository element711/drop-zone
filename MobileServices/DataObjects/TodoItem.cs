using Microsoft.WindowsAzure.Mobile.Service;

namespace MobileServices.DataObjects
{
    /// <summary>
    /// The to-do item.
    /// </summary>
    public class TodoItem : EntityData
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
    }
}