namespace CeramicsStoreManagementWebApps.Models
{
    public class Price
    {
        public int ID { get; set; }
        public double Purches { get; set; }
        public double MinSelling { get; set; }
        public double MaxSelling { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}