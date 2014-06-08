namespace DropZone.Models
{
    /// <summary>
    /// Represents an unknown aircraft.
    /// </summary>
    public class UnknownAircraft : IAircraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownAircraft"/> class.
        /// </summary>
        public UnknownAircraft()
        {
            Name = "Other Aircraft";
        }
        
        /// <summary>
        /// Gets the name of the aircraft.
        /// </summary>
        public string Name { get; private set; }
    }
}