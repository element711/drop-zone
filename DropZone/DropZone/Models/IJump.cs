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
        string JumpNumber { get; set; }

        /// <summary>
        /// Gets the date of the jump.
        /// </summary>
        DateTime JumpDate { get; set; }

        /// <summary>
        /// Gets the location of the jump.
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets the aircraft the jump was performed out of.
        /// </summary>
        string Aircraft { get; set; }

        /// <summary>
        /// Gets the altitude of the jump.
        /// </summary>
        int Altitude { get; set; }

        /// <summary>
        /// Gets the manoeuvre performed during the jump.
        /// </summary>
        string Manoeuvre { get; set; }

        /// <summary>
        /// Gets the freefall delay of the jump.
        /// </summary>
        int FreefallDelay { get; set; }

        /// <summary>
        /// Gets the total time of the jump in seconds.
        /// </summary>
        int TotalTime { get; set; }

        /// <summary>
        /// Gets the container used for the jump.
        /// </summary>
        string Container { get; set; }

        /// <summary>
        /// Gets the description of the jump.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets the thumbnail image.
        /// </summary>
        Uri ThumbnailImage { get; set; }
    }
}