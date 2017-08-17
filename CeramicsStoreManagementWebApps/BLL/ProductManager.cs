using CeramicsStoreManagementWebApps.Gateway;
using CeramicsStoreManagementWebApps.Models;

namespace CeramicsStoreManagementWebApps.BLL
{
    public class ProductManager
    {
        ProductGateway aProductGateway = new ProductGateway();
        public Product GetProductID()
        {
            return aProductGateway.GetProductID();
        }
    }
}