namespace DropZone.Repository
{
    /// <summary>
    /// Represents the result of calling the Azure mobile service.
    /// </summary>
    public enum AzureMobileServicesResult
    {
        /// <summary>
        /// Represents successfully calling Azure mobile services.
        /// </summary>
        Success,

        /// <summary>
        /// Represents failing to call Azure mobile services.
        /// </summary>
        Failure
    }
}