namespace DropZone.Models
{
    /// <summary>
    /// Represents an unknown jump type..
    /// </summary>
    public class UnknownJumpType : IJumpType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownJumpType"/> class.
        /// </summary>
        public UnknownJumpType()
        {
            Name = "Other";
        }
        
        /// <summary>
        /// The name of the type of jump.
        /// </summary>
        public string Name { get; private set; }
    }
}