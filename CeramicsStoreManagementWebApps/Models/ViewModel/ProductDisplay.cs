namespace CeramicsStoreManagementWebApps.Models.ViewModel
{
    public class ProductDisplay
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public double MinSellingPrice { get; set; }
        public double MaxSellingPrice { get; set; }
        public string ManufacturingCountry { get; set; }
        public int Quentity { get; set; }
    }
}