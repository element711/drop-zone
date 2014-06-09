namespace DropZone.Models
{
    /// <summary>
    /// Represents a type of jump.
    /// </summary>
    public interface IJumpType
    {
        /// <summary>
        /// The name of the type of jump.
        /// </summary>
        string Name { get; }
    }
}