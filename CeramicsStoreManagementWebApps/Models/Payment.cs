namespace CeramicsStoreManagementWebApps.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public double TotalCost { get; set; }
        public double TotalDue { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

    }
}