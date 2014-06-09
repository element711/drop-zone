using System;
using DropZone.Annotations;

namespace DropZone.Models
{
    /// <summary>
    /// Represents a type of jump.
    /// </summary>
    public class JumpType : IJumpType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JumpType"/> class.
        /// </summary>
        public JumpType([NotNull] string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
        }

        /// <summary>
        /// The name of the type of jump.
        /// </summary>
        public string Name { get; private set; }
    }
}