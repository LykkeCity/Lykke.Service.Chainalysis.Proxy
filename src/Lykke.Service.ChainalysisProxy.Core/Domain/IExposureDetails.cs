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
        long SentIndirectExposure { get; set; }

        /// <summary>
        /// Funds Sent Directly
        /// </summary>
        long SentDirectExposure { get; set; }

        /// <summary>
        /// Funds Received Indirectly
        /// </summary>
        long ReceivedIndirectExposure { get; set; }

        /// <summary>
        /// Funds Received Directly
        /// </summary>
        long ReceivedDirectExposure { get; set; }
    }
}
