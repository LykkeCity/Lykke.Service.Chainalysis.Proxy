namespace Lykke.Service.ChainalysisProxy.Contracts
{
    public class ExposureDetails 
    {
       
        public string Category { get; set; }
        public int SentIndirectExposure { get; set; }
        public int SentDirectExposure { get; set; }
        public int ReceivedIndirectExposure { get; set; }
        public int ReceivedDirectExposure { get; set; }
    }
}
