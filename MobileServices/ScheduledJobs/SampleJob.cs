using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;

namespace MobileServices.ScheduledJobs
{
    /// <summary>
    /// A simple scheduled job which can be invoked manually by submitting an HTTP
    /// POST request to the path "/jobs/sample". 
    /// </summary>
    public class SampleJob : ScheduledJob
    {
        /// <summary>
        /// When implemented in a derived class, executes the scheduled job asynchronously. Implementations that want to know whether
        /// the scheduled job is being cancelled can get a <see cref="P:Microsoft.WindowsAzure.Mobile.Service.ScheduledJob.CancellationToken" /> from the <see cref="M:CancellationToken" /> property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Web.Http.TraceWriterExtensions.Info(System.Web.Http.Tracing.ITraceWriter,System.String,System.Net.Http.HttpRequestMessage,System.String)")]
        public override Task ExecuteAsync()
        {
            Services.Log.Info("Hello from scheduled job!");
            return Task.FromResult(true);
        }
    }
}