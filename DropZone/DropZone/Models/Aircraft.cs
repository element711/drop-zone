using System;
using DropZone.Annotations;

namespace DropZone.Models
{
    /// <summary>
    /// Represents an aircraft.
    /// </summary>
    public class Aircraft : IAircraft
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Aircraft"/> class.
        /// </summary>
        public Aircraft([NotNull] string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
        }

        /// <summary>
        /// Gets the name of the aircraft.
        /// </summary>
        public string Name { get; private set; }
    }
}