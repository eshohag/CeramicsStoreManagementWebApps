using System.ComponentModel.DataAnnotations;

namespace CeramicsStoreManagementWebApps.Models
{
    public class Client
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter a Client Name !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter a Client Mobile No !")]
        public string ContactNo { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter a Client Address")]
        public string Address { get; set; }
        public int ReferenceID { get; set; }
        public virtual Reference Reference { get; set; }

        //public int BillingID { get; set; }
        //public List<Billing> Billing { get; set; }
    }
}