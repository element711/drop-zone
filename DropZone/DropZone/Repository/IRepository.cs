using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Models;

namespace DropZone.Repository
{
    /// <summary>
    /// Responsible for saving and loading jump log entries for the application.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves the specified jump.
        /// </summary>
        Task Save(IJump jump);

        /// <summary>
        /// Loads a list of all the jumps.
        /// </summary>
        Task<IEnumerable<IJump>> LoadAllJumps();
    }
}
