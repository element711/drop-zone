using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DropZone.Annotations;
using DropZone.DependencyService;
using DropZone.iOS;
using DropZone.Repository;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureMobileService_iOS))]
namespace DropZone.iOS
{
    /// <summary>
    /// Responsible for saving and loading data using Azure mobile services.
    /// </summary>
    public class AzureMobileService_iOS : DelegatingHandler, IAzureMobileService
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

        private IMobileServiceTable<JumpItem> RetrieveJumpTable()
        {
            const string applicationUrl = @"http://dropzoneapp.azure-mobile.net/"; // TODO: pull this out to constants file
            const string applicationKey = @"bsMvKUXhqtbSmLwpAZoBYxrpWmOxgB15";
			
            CurrentPlatform.Init();
            MobileServiceClient client = new MobileServiceClient(applicationUrl, applicationKey, this);
            return client.GetTable<JumpItem>();
        }

        #region implemented abstract members of HttpMessageHandler

        /// <summary>
        /// DelegatingHandler - Send async.
        /// </summary>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        #endregion

    }
}