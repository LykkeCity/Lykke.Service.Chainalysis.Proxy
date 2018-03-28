using Lykke.Service.Chainalysis.Mock.Contracts;
using Lykke.Service.ChainalysisProxy.Core.Domain;

namespace Lykke.Service.ChainalysisProxy.Services
{
    public class ExposureDetails : IExposureDetails
    {
        public ExposureDetails(UserExplosureDetailsModel exposureDetails)
        {
            Category = exposureDetails.Category;
            SentIndirectExposure = exposureDetails.SentIndirectExposure;
            SentDirectExposure = exposureDetails.SentDirectExposure;
            ReceivedIndirectExposure = exposureDetails.ReceivedIndirectExposure;
            ReceivedDirectExposure = exposureDetails.ReceivedDirectExposure;
        }

        public string Category { get; set; }
        public long SentIndirectExposure { get; set; }
        public long SentDirectExposure { get; set; }
        public long ReceivedIndirectExposure { get; set; }
        public long ReceivedDirectExposure { get; set; }
    }
}
