namespace Lykke.Service.ChainalysisProxy.Core.Domain
{
    /// <summary>
    /// Exposure Details
    /// </summary>
    public interface IExposureDetails
    {
        /// <summary>
        /// Exposure category.
        /// </summary>
        string Category { get; set; }

        /// <summary>
        /// Funds Sent Indirectly
        /// </summary>
        int SentIndirectExposure { get; set; }

        /// <summary>
        /// Funds Sent Directly
        /// </summary>
        int SentDirectExposure { get; set; }

        /// <summary>
        /// Funds Received Indirectly
        /// </summary>
        int ReceivedIndirectExposure { get; set; }

        /// <summary>
        /// Funds Received Directly
        /// </summary>
        int ReceivedDirectExposure { get; set; }
    }
}
