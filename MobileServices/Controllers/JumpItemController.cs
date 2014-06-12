using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using MobileServices.DataObjects;
using System;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using MobileServices.Models;

namespace MobileServices.Controllers
{
    /// <summary>
    /// TODO Controller.
    /// </summary>
    public class JumpItemController : TableController<JumpItem>
    {
        /// <summary>
        /// Initializes the <see cref="T:System.Web.Http.ApiController" /> instance with the specified controllerContext.
        /// </summary>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServicesContext context = new MobileServicesContext();
            DomainManager = new EntityDomainManager<JumpItem>(context, Request, Services);
        }

        /// <summary>
        /// Gets all to-do items.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IQueryable<JumpItem> GetAllJumpItems()
        {
            return Query();
        }

        /// <summary>
        /// Gets the to-do item.
        /// </summary>
        public SingleResult<JumpItem> GetJumpItem(string id)
        {
            return Lookup(id);
        }

        /// <summary>
        /// Patches the to-do item.
        /// </summary>
        public Task<JumpItem> PatchJumpItem(string id, Delta<JumpItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        /// <summary>
        /// Posts the to-do item.
        /// </summary>
        public async Task<IHttpActionResult> PostJumpItem(JumpItem item)
        {
            string storageAccountName;
            string storageAccountKey;

            // Try to get the Azure storage account token from app settings.  
            if (!(Services.Settings.TryGetValue("STORAGE_ACCOUNT_NAME", out storageAccountName) |
            Services.Settings.TryGetValue("STORAGE_ACCOUNT_ACCESS_KEY", out storageAccountKey)))
            {
                Services.Log.Error("Could not retrieve storage account settings.");
            }

            // Set the URI for the Blob Storage service.
            Uri blobEndpoint = new Uri(string.Format("https://{0}.blob.core.windows.net", storageAccountName));

            // Create the BLOB service client.
            CloudBlobClient blobClient = new CloudBlobClient(blobEndpoint, 
                new StorageCredentials(storageAccountName, storageAccountKey));

            if (item.ContainerName != null)
            {
                // Set the BLOB store container name on the item, which must be lowercase.
                item.ContainerName = item.ContainerName.ToLower();

                // Create a container, if it doesn't already exist.
                CloudBlobContainer container = blobClient.GetContainerReference(item.ContainerName);
                await container.CreateIfNotExistsAsync();

                // Create a shared access permission policy. 
                BlobContainerPermissions containerPermissions = new BlobContainerPermissions();

                // Enable anonymous read access to BLOBs.
                containerPermissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(containerPermissions);

                // Define a policy that gives write access to the container for 5 minutes.                                   
                SharedAccessBlobPolicy sasPolicy = new SharedAccessBlobPolicy()
                {
                    SharedAccessStartTime = DateTime.UtcNow,
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(5),
                    Permissions = SharedAccessBlobPermissions.Write
                };

                // Get the SAS as a string.
                item.SasQueryString = container.GetSharedAccessSignature(sasPolicy); 

                // Set the URL used to store the image.
                item.ImageUri = string.Format("{0}{1}/{2}", blobEndpoint.ToString(), 
                    item.ContainerName, item.ResourceName);
            }

            // Complete the insert operation.
            JumpItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }


        /// <summary>
        /// Deletes the to-do item.
        /// </summary>
        public Task DeleteJumpItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}