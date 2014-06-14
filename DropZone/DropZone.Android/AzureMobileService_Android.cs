using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.DependencyService;
using DropZone.Droid;
using DropZone.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureMobileService_Android))]
namespace DropZone.Droid
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class AzureMobileService_Android : Java.Lang.Object, IAzureMobileService
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
            const string applicationUrl = @"http://dropzoneapp.azure-mobile.net/";
            const string applicationKey = @"bsMvKUXhqtbSmLwpAZoBYxrpWmOxgB15";

            CurrentPlatform.Init();
            MobileServiceClient client = new MobileServiceClient(applicationUrl, applicationKey);
            return client.GetTable<JumpItem>();
        }
    }
}