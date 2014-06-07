using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.Models;
using DropZone.Repository;

namespace DropZone.ViewModels
{
    /// <summary>
    /// The main gallery page view model.
    /// </summary>
    public class MainGalleyPageViewModel : INotifyPropertyChanged
    {
        private readonly IRepository _repository;
        private IEnumerable<JumpViewModel> _leftJumps;
        private IEnumerable<JumpViewModel> _middleJumps;
        private IEnumerable<JumpViewModel> _rightJumps;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainGalleyPageViewModel"/> class.
        /// </summary>
        public MainGalleyPageViewModel([NotNull] IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
            _leftJumps = new List<JumpViewModel>();
            _middleJumps = new List<JumpViewModel>();
            _rightJumps = new List<JumpViewModel>();
        }

        /// <summary>
        /// Called when the page has been loaded.
        /// </summary>
        public async Task OnLoad()
        {
            List<JumpViewModel> leftJumps = new List<JumpViewModel>();
            List<JumpViewModel> middleJumps = new List<JumpViewModel>();
            List<JumpViewModel> rightJumps = new List<JumpViewModel>();

            IList<IJump> jumps = (await _repository.LoadAllJumps()).ToList();

            for (int i = 0; i < jumps.Count(); i = i + 3)
            {
                if (i < jumps.Count())
                {
                    leftJumps.Add(new JumpViewModel(jumps[i], _repository));                    
                }
                if (i + 1 < jumps.Count())
                {
                    middleJumps.Add(new JumpViewModel(jumps[i + 1], _repository));                    
                }
                if (i + 2 < jumps.Count())
                {
                    rightJumps.Add(new JumpViewModel(jumps[i + 2], _repository));                    
                }
            }

            LeftJumps = leftJumps;
            MiddleJumps = middleJumps;
            RightJumps = rightJumps;
        }

        /// <summary>
        /// Gets the jumps to be displayed in the left column.
        /// </summary>
        [NotNull]
        public IEnumerable<JumpViewModel> LeftJumps
        {
            get { return _leftJumps; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _leftJumps = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the jumps to be displayed in the middle column.
        /// </summary>
        [NotNull]
        public IEnumerable<JumpViewModel> MiddleJumps
        {
            get { return _middleJumps; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _middleJumps = value;
                OnPropertyChanged();
            }

        }
        
        /// <summary>
        /// Gets the jumps to be displayed in the right column.
        /// </summary>
        [NotNull]
        public IEnumerable<JumpViewModel> RightJumps
        {
            get { return _rightJumps; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                _rightJumps = value;
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