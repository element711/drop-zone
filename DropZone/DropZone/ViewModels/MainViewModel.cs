using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.Models;
using DropZone.Repository;

namespace DropZone.ViewModels
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FakeRepository _repository;
        private IEnumerable<JumpViewModel> _jumps;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainViewModel()
        {
            _repository = new FakeRepository();
            _jumps = new List<JumpViewModel>();
        }

        /// <summary>
        /// Called when the page has been loaded.
        /// </summary>
        public async Task OnLoad()
        {
            IEnumerable<IJump> jumps = await _repository.LoadAllJumps();
            List<JumpViewModel> jumpViewModels = new List<JumpViewModel>();
            foreach (IJump jump in jumps)
            {
                jumpViewModels.Add(new JumpViewModel(jump));
            }
            Jumps = jumpViewModels;
        }

        /// <summary>
        /// Gets the jumps.
        /// </summary>
        [NotNull]
        public IEnumerable<JumpViewModel> Jumps
        {
            get { return _jumps; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _jumps = value;
                OnPropertyChanged();
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
    }
}