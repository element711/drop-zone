using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.DependencyService;
using DropZone.iOS;
using DropZone.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureMobileService_iOS))]
namespace DropZone.iOS
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class AzureMobileService_iOS : IAzureMobileService
    {
        /// <summary>
        /// Inserts the specified jump.
        /// </summary>
        public async Task Insert(JumpItem jump)
        {
            await Task.Delay(0);
        }

        /// <summary>
        /// Loads all jumps.
        /// </summary>
        public async Task<IList<JumpItem>> LoadAllJumps()
        {
            await Task.Delay(0);
            return new List<JumpItem>();
        }
    }
}