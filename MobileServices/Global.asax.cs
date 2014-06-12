using System.Web.Http;
using System.Web.Routing;

namespace MobileServices
{
    /// <summary>
    /// The Web API application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application start.
        /// </summary>
        protected void Application_Start()
        {
            WebApiConfig.Register();
        }
    }
}