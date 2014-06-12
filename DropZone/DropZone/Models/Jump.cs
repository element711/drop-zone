using System;
using DropZone.Annotations;

namespace DropZone.Models
{
    /// <summary>
    /// Represents a jump log entry.
    /// </summary>
    public class Jump : IJump
    {
        private string _jumpNumber;
        private DateTime _jumpDate;
        private string _location;
        private IAircraft _aircraft;
        private int _altitude;
        private IJumpType _jumpType;
        private int _freefallDelay;
        private int _totalTime;
        private string _container;
        private string _description;
        private byte[] _thumbnailImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Jump"/> class.
        /// </summary>
        public Jump()
        {
            _jumpDate = DateTime.Now;
            _jumpNumber = string.Empty;
            _location = string.Empty;
            _aircraft = new UnknownAircraft();
            _altitude = 0;
            _jumpType = new UnknownJumpType();
            _freefallDelay = 0;
            _totalTime = 0;
            _container = string.Empty;
            _description = string.Empty;
            _thumbnailImage = new byte[0];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Jump"/> class.
        /// </summary>
        public Jump([NotNull] string jumpNumber, DateTime jumpDate, [NotNull] string location, [NotNull] IAircraft aircraft, int altitude,
            [NotNull] IJumpType jumpType, int freefallDelay, int totalTime, [NotNull] string container,
            [NotNull] string description, [NotNull] byte[] thumbnailImage)
        {
            if (jumpNumber == null) throw new ArgumentNullException("jumpNumber");
            if (location == null) throw new ArgumentNullException("location");
            if (aircraft == null) throw new ArgumentNullException("aircraft");
            if (jumpType == null) throw new ArgumentNullException("jumpType");
            if (container == null) throw new ArgumentNullException("container");
            if (description == null) throw new ArgumentNullException("description");
            if (thumbnailImage == null) throw new ArgumentNullException("thumbnailImage");

            _jumpNumber = jumpNumber;
            _jumpDate = jumpDate;
            _location = location;
            _aircraft = aircraft;
            _altitude = altitude;
            _jumpType = jumpType;
            _freefallDelay = freefallDelay;
            _totalTime = totalTime;
            _container = container;
            _description = description;
            _thumbnailImage = thumbnailImage;
        }

        /// <summary>
        /// Gets the jump number.
        /// </summary>
        public string JumpNumber
        {
            get { return _jumpNumber; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _jumpNumber = value;
            }
        }

        /// <summary>
        /// Gets the date of the jump.
        /// </summary>
        public DateTime JumpDate
        {
            get { return _jumpDate; }
            set { _jumpDate = value; }
        }

        /// <summary>
        /// Gets the location of the jump.
        /// </summary>
        public string Location
        {
            get { return _location; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _location = value;
            }
        }

        /// <summary>
        /// Gets the aircraft the jump was performed out of.
        /// </summary>
        public IAircraft Aircraft
        {
            get { return _aircraft; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _aircraft = value;
            }
        }

        /// <summary>
        /// Gets the altitude of the jump.
        /// </summary>
        public int Altitude
        {
            get { return _altitude; }
            set { _altitude = value; }
        }

        /// <summary>
        /// Gets the jump type manoeuvre performed.
        /// </summary>
        public IJumpType JumpType
        {
            get { return _jumpType; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _jumpType = value;
            }
        }

        /// <summary>
        /// Gets the freefall delay of the jump.
        /// </summary>
        public int FreefallDelay
        {
            get { return _freefallDelay; }
            set { _freefallDelay = value; }
        }

        /// <summary>
        /// Gets the total time of the jump in seconds.
        /// </summary>
        public int TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }

        /// <summary>
        /// Gets the container used for the jump.
        /// </summary>
        public string Container
        {
            get { return _container; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _container = value;
            }
        }

        /// <summary>
        /// Gets the description of the jump.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _description = value;
            }
        }

        /// <summary>
        /// Gets the thumbnail image.
        /// </summary>
        public byte[] ThumbnailImage
        {
            get { return _thumbnailImage; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                 _thumbnailImage = value;
            }
        }
    }
}
