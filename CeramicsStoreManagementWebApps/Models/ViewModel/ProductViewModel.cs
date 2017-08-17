using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreManagementWebApps.Models.ViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter your Product Name!")]
        public string Name { get; set; }

        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }
        public List<Brand> Brand { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }

        [Required(ErrorMessage = "Enter your Product Purches Price!")]

        public double PurchesPrice { get; set; }
        [Required(ErrorMessage = "Enter your Product Minimum Selling Price!")]

        public double MinSellingPrice { get; set; }
        [Required(ErrorMessage = "Enter your Product Maximum Selling Price!")]
        public double MaxSellingPrice { get; set; }
        [Required(ErrorMessage = "Enter your Product Quentity!")]

        public int Quentity { get; set; }

    }
}