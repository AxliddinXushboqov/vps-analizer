namespace VPS_Analizer.Models.Clients
{
    public class Client
    {
        public string ClientLogin { get; set; }
        public string AccountBalance { get; set; }
        public string AccountEquity { get; set; }
        public bool InvestorStatus { get; set; }
        public string ServerRam { get; set; }
        public string ServerCpu { get; set; }
        public bool ClientStatus { get; set; }
        public string ProblemDescription { get; set; }
    }
}
