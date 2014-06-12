using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using MobileServices.DataObjects;
using MobileServices.Models;

namespace MobileServices.Controllers
{
    /// <summary>
    /// TODO Controller.
    /// </summary>
    public class TodoItemController : TableController<TodoItem>
    {
        /// <summary>
        /// Initializes the <see cref="T:System.Web.Http.ApiController" /> instance with the specified controllerContext.
        /// </summary>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServicesContext context = new MobileServicesContext();
            DomainManager = new EntityDomainManager<TodoItem>(context, Request, Services);
        }

        /// <summary>
        /// Gets all to-do items.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public IQueryable<TodoItem> GetAllTodoItems()
        {
            return Query();
        }

        /// <summary>
        /// Gets the to-do item.
        /// </summary>
        public SingleResult<TodoItem> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        /// <summary>
        /// Patches the to-do item.
        /// </summary>
        public Task<TodoItem> PatchTodoItem(string id, Delta<TodoItem> patch)
        {
            return UpdateAsync(id, patch);
        }

        /// <summary>
        /// Posts the to-do item.
        /// </summary>
        public async Task<IHttpActionResult> PostTodoItem(TodoItem item)
        {
            TodoItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }


        /// <summary>
        /// Deletes the to-do item.
        /// </summary>
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}