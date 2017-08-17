using System.Collections.Generic;

namespace CeramicsStoreManagementWebApps.Models
{
    public class Billing
    {
        public int ID { get; set; }
        public double Total { get; set; }
        public double Profit { get; set; }
        public double Loss { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public int ProductID { get; set; }
        public List<Product> Product { get; set; }
        public int PaymentID { get; set; }
        public Payment Payment { get; set; }

    }
}