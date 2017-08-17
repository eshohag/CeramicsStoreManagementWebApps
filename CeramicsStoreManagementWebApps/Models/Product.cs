namespace CeramicsStoreManagementWebApps.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }




    }
}