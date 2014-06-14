using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Repository;

namespace DropZone.DependencyService
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public interface IAzureMobileService
    {
        /// <summary>
        /// Inserts the specified jump.
        /// </summary>
        Task Insert(JumpItem jump);

        /// <summary>
        /// Loads all jumps.
        /// </summary>
        Task<IList<JumpItem>> LoadAllJumps();
    }
}