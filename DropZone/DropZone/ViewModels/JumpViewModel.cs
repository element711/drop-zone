using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.Models;
using DropZone.Repository;
using Xamarin.Forms;

namespace DropZone.ViewModels
{
    /// <summary>
    /// The jump view model.
    /// </summary>
    public class JumpViewModel : INotifyPropertyChanged
    {
        private readonly IRepository _repository;
        private readonly IJump _jump;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpViewModel"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JumpViewModel([NotNull] IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            _repository = repository;
            _jump = new Jump();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JumpViewModel"/> class.
        /// </summary>
        public JumpViewModel([NotNull] IJump jump, [NotNull] IRepository repository)
        {
            if (jump == null) throw new ArgumentNullException("jump");
            if (repository == null) throw new ArgumentNullException("repository");

            _jump = jump;
            _repository = repository;
        }

        /// <summary>
        /// Gets or sets the jump number.
        /// </summary>
        [NotNull]
        public string JumpNumber
        {
            get { return _jump.JumpNumber; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                if (value.Equals(_jump.JumpNumber))
                {
                    return;
                }
                _jump.JumpNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the date of the jump.
        /// </summary>
        public DateTime JumpDate
        {
            get { return _jump.JumpDate; }
            set
            {
                if (value.Equals(_jump.JumpDate))
                {
                    return;
                }
                _jump.JumpDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the location of the jump.
        /// </summary>
        [NotNull]
        public string Location
        {
            get { return _jump.Location; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                if (value.Equals(_jump.Location, StringComparison.Ordinal))
                {
                    return;
                }
                _jump.Location = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the aircraft.
        /// </summary>
        [NotNull]
        public IAircraft Aircraft
        {
            get { return _jump.Aircraft; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                _jump.Aircraft = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the altitude of the jump.
        /// </summary>
        public string Altitude
        {
            get { return _jump.Altitude == 0 ? string.Empty : _jump.Altitude.ToString(CultureInfo.CurrentCulture); }
            set
            {
                _jump.Altitude = string.IsNullOrEmpty(value) ? 0 : int.Parse(value, CultureInfo.CurrentCulture);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the jump type manoeuvre performed.
        /// </summary>
        [NotNull]
        public IJumpType JumpType
        {
            get { return _jump.JumpType; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                _jump.JumpType = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the freefall delay.
        /// </summary>
        public string FreefallDelay
        {
            get { return _jump.FreefallDelay == 0 ? string.Empty : _jump.FreefallDelay.ToString(CultureInfo.CurrentCulture); }
            set
            {
                _jump.FreefallDelay = string.IsNullOrEmpty(value) ? 0 : int.Parse(value, CultureInfo.CurrentCulture);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        public string TotalTime
        {
            get
            {
                return _jump.TotalTime == 0 ? string.Empty : _jump.TotalTime.ToString(CultureInfo.CurrentCulture);
            }
            set
            {
                _jump.TotalTime = string.IsNullOrEmpty(value) ? 0 : int.Parse(value, CultureInfo.CurrentCulture);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        [NotNull]
        public string Container
        {
            get { return _jump.Container; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                if (value.Equals(_jump.Container, StringComparison.Ordinal))
                {
                    return;
                }
                _jump.Container = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [NotNull]
        public string Description
        {
            get { return _jump.Description; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");

                if (value.Equals(_jump.Description, StringComparison.Ordinal))
                {
                    return;
                }
                _jump.Description = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public ImageSource ThumbnailImage
        {
            get
            {
                if (_jump.ThumbnailImage.Length > 0)
                {
                    return ImageSource.FromStream(() => new MemoryStream(_jump.ThumbnailImage));                    
                }
                return null;
            }
        }

        /// <summary>
        /// Called when a property is changed.
        /// </summary>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Saves this jump.
        /// </summary>
        public async Task Save()
        {
            await _repository.Save(_jump);
        }

        /// <summary>
        /// Updates the selected image.
        /// </summary>
        public void UpdateImage([NotNull] Stream image)
        {
            if (image == null) throw new ArgumentNullException("image");
            
            using (MemoryStream ms = new MemoryStream())
            {
                image.CopyTo(ms);
                _jump.ThumbnailImage = ms.ToArray();
            }
            OnPropertyChanged("ThumbnailImage");
        }
    }
}
