using CeramicsStoreManagementWebApps.Gateway;
using CeramicsStoreManagementWebApps.Models;
using CeramicsStoreManagementWebApps.Models.ViewModel;
using System.Collections.Generic;

namespace CeramicsStoreManagementWebApps.BLL
{
    public class ProductManager
    {
        ProductGateway aProductGateway = new ProductGateway();
        public Product GetProductID()
        {
            return aProductGateway.GetProductID();
        }

        public List<ProductDisplay> GetAllProduct()
        {
            return aProductGateway.GetAllProduct();
        }
    }
}