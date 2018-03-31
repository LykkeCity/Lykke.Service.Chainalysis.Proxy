namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class ExposureDetails 
    {
       
        public string Category { get; set; }
        public long SentIndirectExposure { get; set; }
        public long SentDirectExposure { get; set; }
        public long ReceivedIndirectExposure { get; set; }
        public long ReceivedDirectExposure { get; set; }
    }
}
