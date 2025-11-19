namespace VPS_Analizer.Models.Clients
{
    public class Client
    {
        public string VpsId { get; set; }
        public string ClientLogin { get; set; }
        public string AccountBalance { get; set; }
        public string AccountEquity { get; set; }
        public bool RobotStatus { get; set; }
        public string ServerRam { get; set; }
        public string ServerCpu { get; set; }
        public string ProblemDescription { get; set; }
    }
}