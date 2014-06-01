using System;
using DropZone.Annotations;

namespace DropZone.Models
{
    /// <summary>
    /// Represents a jump log entry.
    /// </summary>
    public class Jump : IJump
    {
        private readonly uint _jumpNumber;
        private readonly DateTime _jumpDate;
        private readonly string _location;
        private readonly string _aircraft;
        private readonly uint _altitude;
        private readonly string _manoeuvre;
        private readonly uint _freefallDelay;
        private readonly uint _totalTime;
        private readonly string _container;
        private readonly string _description;

        /// <summary>
        /// Initializes a new instance of the <see cref="Jump"/> class.
        /// </summary>
        public Jump(uint jumpNumber, DateTime jumpDate, [NotNull] string location, [NotNull] string aircraft, uint altitude,
            [NotNull] string manoeuvre, uint freefallDelay, uint totalTime, [NotNull] string container,
            [NotNull] string description)
        {
            if (location == null) throw new ArgumentNullException("location");
            if (aircraft == null) throw new ArgumentNullException("aircraft");
            if (manoeuvre == null) throw new ArgumentNullException("manoeuvre");
            if (container == null) throw new ArgumentNullException("container");
            if (description == null) throw new ArgumentNullException("description");

            _jumpNumber = jumpNumber;
            _jumpDate = jumpDate;
            _location = location;
            _aircraft = aircraft;
            _altitude = altitude;
            _manoeuvre = manoeuvre;
            _freefallDelay = freefallDelay;
            _totalTime = totalTime;
            _container = container;
            _description = description;
        }

        /// <summary>
        /// Gets the jump number.
        /// </summary>
        public uint JumpNumber
        {
            get { return _jumpNumber; }
        }

        /// <summary>
        /// Gets the date of the jump.
        /// </summary>
        public DateTime JumpDate
        {
            get { return _jumpDate; }
        }

        /// <summary>
        /// Gets the location of the jump.
        /// </summary>
        public string Location
        {
            get { return _location; }
        }

        /// <summary>
        /// Gets the aircraft the jump was performed out of.
        /// </summary>
        public string Aircraft
        {
            get { return _aircraft; }
        }

        /// <summary>
        /// Gets the altitude of the jump.
        /// </summary>
        public uint Altitude
        {
            get { return _altitude; }
        }

        /// <summary>
        /// Gets the manoeuvre performed during the jump.
        /// </summary>
        public string Manoeuvre
        {
            get { return _manoeuvre; }
        }

        /// <summary>
        /// Gets the freefall delay of the jump.
        /// </summary>
        public uint FreefallDelay
        {
            get { return _freefallDelay; }
        }

        /// <summary>
        /// Gets the total time of the jump in seconds.
        /// </summary>
        public uint TotalTime
        {
            get { return _totalTime; }
        }

        /// <summary>
        /// Gets the container used for the jump.
        /// </summary>
        public string Container
        {
            get { return _container; }
        }

        /// <summary>
        /// Gets the description of the jump.
        /// </summary>
        public string Description
        {
            get { return _description; }
        }
    }
}
