using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Repository;

namespace DropZone.DependencyService
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public interface IAzureJumpMobileServiceClient
    {
        /// <summary>
        /// Gets the jump items.
        /// </summary>
        Task<IEnumerable<JumpItem>> GetItems();

        /// <summary>
        /// Inserts the specified jump item.
        /// </summary>
        Task Insert(JumpItem jump);

        /// <summary>
        /// Updates the specified jump item.
        /// </summary>
        Task Update(JumpItem jump);
    }
}