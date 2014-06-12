using System.Threading.Tasks;

namespace DropZone.ViewModels
{
    /// <summary>
    /// Represents a view model.
    /// </summary>
    public interface IRefreshableViewModel
    {
        /// <summary>
        /// Refreshes the data.
        /// </summary>
        Task Refresh();
    }
}