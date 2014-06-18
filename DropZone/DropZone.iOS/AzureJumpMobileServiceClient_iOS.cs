using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DropZone.DependencyService;
using DropZone.iOS;
using DropZone.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureJumpMobileServiceClient_iOS))]
namespace DropZone.iOS
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class AzureJumpMobileServiceClient_iOS : DelegatingHandler, IAzureJumpMobileServiceClient
    {
        /// <summary>
        /// Gets the jump items.
        /// </summary>
        public async Task<IEnumerable<JumpItem>> GetItems()
        {
            using (MobileServiceClient client = new MobileServiceClient(Settings.MobileServicesApplicationUrl,
                Settings.MobileServicesApplicationKey))
            {
                IMobileServiceTable<JumpItem> table = client.GetTable<JumpItem>();
                return await table.ToListAsync();
            }
        }

        /// <summary>
        /// Inserts the specified jump item.
        /// </summary>
        public async Task Insert(JumpItem jump)
        {
            using (MobileServiceClient client = new MobileServiceClient(Settings.MobileServicesApplicationUrl,
                    Settings.MobileServicesApplicationKey))
            {
                await client.GetTable<JumpItem>().InsertAsync(jump);
            }
        }

        /// <summary>
        /// Updates the specified jump item.
        /// </summary>
        public async Task Update(JumpItem jump)
        {
            using (MobileServiceClient client = new MobileServiceClient(Settings.MobileServicesApplicationUrl,
                    Settings.MobileServicesApplicationKey))
            {
                await client.GetTable<JumpItem>().UpdateAsync(jump);
            }
        }
    }
}