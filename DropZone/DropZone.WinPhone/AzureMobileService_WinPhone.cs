using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.DependencyService;
using DropZone.Repository;
using DropZone.WinPhone;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureMobileService_WinPhone))]
namespace DropZone.WinPhone
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class AzureMobileService_WinPhone : IAzureMobileService
    {
        /// <summary>
        /// Inserts the specified jump.
        /// </summary>
        public async Task Insert([NotNull] JumpItem jump)
        {
            if (jump == null) throw new ArgumentNullException("jump");

            IMobileServiceTable<JumpItem> table = RetrieveJumpTable();
            await table.InsertAsync(jump);
        }

        /// <summary>
        /// Loads all jumps.
        /// </summary>
        public async Task<IList<JumpItem>> LoadAllJumps()
        {
            IMobileServiceTable<JumpItem> table = RetrieveJumpTable();
            List<JumpItem> jumps = await table.ToListAsync();
            return jumps;
        }

        private static IMobileServiceTable<JumpItem> RetrieveJumpTable()
        {
            MobileServiceClient client = new MobileServiceClient(Settings.MobileServicesApplicationUrl, 
                                                                 Settings.MobileServicesApplicationKey);
            return client.GetTable<JumpItem>();
        }
    }
}