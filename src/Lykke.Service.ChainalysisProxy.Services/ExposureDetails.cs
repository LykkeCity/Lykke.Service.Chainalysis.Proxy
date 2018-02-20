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
        public int SentIndirectExposure { get; set; }
        public int SentDirectExposure { get; set; }
        public int ReceivedIndirectExposure { get; set; }
        public int ReceivedDirectExposure { get; set; }
    }
}
