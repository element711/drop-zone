using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.DependencyService;

namespace DropZone.Repository
{
    /// <summary>
    /// Responsible for accessing jumps from the azure mobile service.
    /// </summary>
    public class AzureJumpMobileService 
    {
        private IEnumerable<JumpItem> _jumps;

        private readonly IAzureJumpMobileServiceClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureJumpMobileService"/> class.
        /// </summary>
        public AzureJumpMobileService([NotNull] IAzureJumpMobileServiceClient client)
        {
            if (client == null) throw new ArgumentNullException("client");

            _client = client;
            _jumps = new List<JumpItem>();
        }


        /// <summary>
        /// Saves the specified jump.
        /// </summary>
        public async Task<AzureMobileServicesResult> Save(JumpItem jump)
        {
            try
            {
                if (string.IsNullOrEmpty(jump.Id))
                {
                    await _client.Insert(jump);
                }
                else
                {
                    await _client.Update(jump);
                }
                return AzureMobileServicesResult.Success;
            }
            catch (Exception)
            {
                return AzureMobileServicesResult.Failure;
            }
        }

        /// <summary>
        /// Loads all jumps.
        /// </summary>
        public async Task<IEnumerable<JumpItem>> LoadAllJumps()
        {
            await TryReloadJumps();
            return _jumps;
        }

        private async Task TryReloadJumps()
        {
            try
            {
                _jumps = await _client.GetItems();
            }
            catch (Exception)
            {
            }
        }
    }
}