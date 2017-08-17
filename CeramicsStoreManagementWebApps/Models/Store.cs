using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreManagementWebApps.Models
{
    public class Store
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter a Product Quentity !")]
        public int Quentity { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}