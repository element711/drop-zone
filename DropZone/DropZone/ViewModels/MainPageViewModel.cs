using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.Models;
using DropZone.Repository;
using Xamarin.Forms;

namespace DropZone.ViewModels
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly IRepository _repository;
        private IEnumerable<JumpViewModel> _allJumps;
        private IEnumerable<JumpViewModel> _jumps;
        private INavigation _navigation;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        public MainPageViewModel([NotNull] IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            _repository = repository;
            _allJumps = new List<JumpViewModel>();
            _jumps = new List<JumpViewModel>();
        }

        /// <summary>
        /// Called when the page has been loaded.
        /// </summary>
        public async Task OnLoad([NotNull] INavigation navigation)
        {
            if (navigation == null) throw new ArgumentNullException("navigation");

            _navigation = navigation;
            IEnumerable<IJump> jumps = await _repository.LoadAllJumps();
            List<JumpViewModel> jumpViewModels = new List<JumpViewModel>();
            foreach (IJump jump in jumps)
            {
                jumpViewModels.Add(new JumpViewModel(jump, _repository));
            }
            _allJumps = jumpViewModels;
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

        /// <summary>
        /// Handles when an items is selected.
        /// </summary>
        public void ItemSelected([NotNull] JumpViewModel selectedItem)
        {
            if (selectedItem == null) throw new ArgumentNullException("selectedItem");

            _navigation.PushAsync(App.GetJumpPage(selectedItem));
        }

        /// <summary>
        /// Filters the specified search.
        /// </summary>
        public void Filter([NotNull] string search)
        {
            if (search == null) throw new ArgumentNullException("search");

            if (string.IsNullOrWhiteSpace(search))
            {
                Jumps = _allJumps;                
            }
            Jumps = _allJumps.Where(jump => jump.JumpNumber.ToLower().Contains(search.ToLower()));
        }
    }
}