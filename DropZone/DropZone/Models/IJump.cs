using System;

namespace DropZone.Models
{
    /// <summary>
    /// Represents a jump log entry.
    /// </summary>
    public interface IJump
    {
        /// <summary>
        /// Gets the jump number.
        /// </summary>
        uint JumpNumber { get; }

        /// <summary>
        /// Gets the date of the jump.
        /// </summary>
        DateTime JumpDate { get; }

        /// <summary>
        /// Gets the location of the jump.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the aircraft the jump was performed out of.
        /// </summary>
        string Aircraft { get; }

        /// <summary>
        /// Gets the altitude of the jump.
        /// </summary>
        uint Altitude { get; }

        /// <summary>
        /// Gets the manoeuvre performed during the jump.
        /// </summary>
        string Manoeuvre { get; }

        /// <summary>
        /// Gets the freefall delay of the jump.
        /// </summary>
        uint FreefallDelay { get; }

        /// <summary>
        /// Gets the total time of the jump in seconds.
        /// </summary>
        uint TotalTime { get; }

        /// <summary>
        /// Gets the container used for the jump.
        /// </summary>
        string Container { get; }

        /// <summary>
        /// Gets the description of the jump.
        /// </summary>
        string Description { get; }
    }
}