using CeramicsStoreManagementWebApps.Models;
using CeramicsStoreManagementWebApps.Models.ViewModel;
using System;
using System.Collections.Generic;
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

        public List<ProductDisplay> GetAllProduct()
        {
            Query = "select * from GetAllProduct";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ProductDisplay> aCampaignist = new List<ProductDisplay>();
            while (Reader.Read())
            {
                ProductDisplay aCampaign = new ProductDisplay();
                aCampaign.Name = Reader["Name"].ToString();
                aCampaign.Brand = Reader["Brand"].ToString();
                aCampaign.ManufacturingCountry = Reader["ManufacturingCountry"].ToString();
                aCampaign.MinSellingPrice = Convert.ToDouble(Reader["MinSelling"]);
                aCampaign.MaxSellingPrice = Convert.ToDouble(Reader["MaxSelling"]);
                aCampaign.Quentity = Convert.ToInt32(Reader["Quentity"]);

                aCampaignist.Add(aCampaign);
            }
            Reader.Close();
            Connection.Close();
            return aCampaignist;
        }
    }
}