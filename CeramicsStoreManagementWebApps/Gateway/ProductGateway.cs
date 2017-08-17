using CeramicsStoreManagementWebApps.Models;
using System;
using System.Data.SqlClient;

namespace CeramicsStoreManagementWebApps.Gateway
{
    public class ProductGateway : CommonGateway
    {
        public Product GetProductID()
        {
            Query = "SELECT MAX(ID) as ID FROM Products";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Product aProduct = null;
            while (Reader.Read())
            {
                aProduct = new Product();
                aProduct.ID = Convert.ToInt32(Reader["ID"]);
            }
            Reader.Close();
            Connection.Close();
            return aProduct;
        }
    }
}