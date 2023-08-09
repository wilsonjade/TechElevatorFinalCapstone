using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public class SellerSqlDao : ISellerDao
    {
        private readonly string connectionString;
        //sql statements
        private readonly string sqlGetSellers = @"SELECT seller_id,seller_name,seller_type ,address1,address2 ,city ,state ,zip,website FROM sellers;";
        private readonly string sqlGetSellerById = @"SELECT seller_id,seller_name,seller_type ,address1,address2 ,city ,state ,zip,website FROM sellers
                                                     WHERE @seller_id = sellers.seller_id;";
        private readonly string sqlGetSellerInventoryById = @"SELECT plant_id FROM sellers_products WHERE @seller_id = sellers_products.seller_id;";
        private readonly string sqlCreateSeller = @"INSERT INTO sellers (seller_name,seller_type ,address1,address2 ,city ,state ,zip,website)";
        private readonly string sqlUpdateSeller = @"";
        private readonly string sqlDeleteSeller = @"";

        public SellerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Seller> GetSellers()
        {
            List<Seller> sellerList = new List<Seller>();

            return sellerList;
        }
        public Seller GetSellerById(int sellerId)
        {

            Seller sellerResult = new Seller();

            return sellerResult;
        }
        public List<int> GetSellerInventoryById(int sellerId)
        {
            List<int> inventoryList = new List<int>();

            return inventoryList;
        }
        public Seller CreateSeller(Seller newSeller)
        {
            Seller createdSeller = new Seller();


            return createdSeller;
        }
        public Seller UpdateSeller(Seller sellerToUpdate)
        {
            Seller updatedSeller = new Seller();


            return updatedSeller;
        }
        public bool DeleteSeller(int sellerId)
        {
            bool deleteSuccess = false;



            return deleteSuccess;
        }
    }
}
