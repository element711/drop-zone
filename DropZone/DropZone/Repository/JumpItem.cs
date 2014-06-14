using System;
using DropZone.Annotations;
using DropZone.Models;
using Newtonsoft.Json;

namespace DropZone.Repository
{
    /// <summary>
    /// Represents a jump data transfer object.
    /// </summary>
    public class JumpItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpItem"/> class.
        /// </summary>
        public JumpItem() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpItem"/> class.
        /// </summary>
        public JumpItem([NotNull] IJump jump)
        {
            if (jump == null) throw new ArgumentNullException("jump");

            Aircraft = jump.Aircraft.Name;
            Altitude = jump.Altitude;
            Container = jump.Container;
            Description = jump.Description;
            FreefallDelay = jump.FreefallDelay;
            JumpDate = jump.JumpDate;
            JumpNumber = jump.JumpNumber;
            JumpType = jump.JumpType.Name;
            Location = jump.Location;
            TotalTime = jump.TotalTime;
        }

        /// <summary>
        /// Gets or sets the jump number.
        /// </summary>
        [JsonProperty(PropertyName = "jumpNumber")]
        public string JumpNumber { get; set; }

        /// <summary>
        /// Gets or sets the jump date.
        /// </summary>
        [JsonProperty(PropertyName = "jumpDate")]
        public DateTime JumpDate { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the aircraft.
        /// </summary>
        [JsonProperty(PropertyName = "aircraft")]
        public string Aircraft { get; set; }

        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        [JsonProperty(PropertyName = "altitude")]
        public int Altitude { get; set; }

        /// <summary>
        /// Gets or sets the type of the jump.
        /// </summary>
        [JsonProperty(PropertyName = "jumpType")]
        public string JumpType { get; set; }

        /// <summary>
        /// Gets or sets the freefall delay.
        /// </summary>
        [JsonProperty(PropertyName = "freefallDelay")]
        public int FreefallDelay { get; set; }

        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        [JsonProperty(PropertyName = "totalTime")]
        public int TotalTime { get; set; }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        [JsonProperty(PropertyName = "container")]
        public string Container { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

//        public byte[] ThumbnailImage { get; set; }
    }
}
