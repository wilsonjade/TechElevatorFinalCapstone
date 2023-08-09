using Capstone.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        private readonly string sqlCreateSeller = @"INSERT INTO sellers 
                                                         (seller_name,seller_type ,address1,address2 ,city ,state ,zip,website)
                                                  VALUES (@seller_name,@seller_type ,@address1,@address2 ,@city ,@state ,@zip,@website)";
        private readonly string sqlUpdateSeller = @"UPDATE sellers
                                                    SET
                                                        seller_name = @seller_name,
                                                        seller_type = @seller_type,
                                                        address1 = @address1,
                                                        address2 = @address2,
                                                        city = @city,
                                                        state = @state,
                                                        zip = @zip,
                                                        website = @website,
                                                    WHERE
                                                        seller_id = @seller_id;";
        private readonly string sqlDeleteSeller = @"DELETE FROM sellers WHERE @seller_id = sellers.seller_id";

        public SellerSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        private Seller MapRowToSeller(SqlDataReader reader)
        {
            Seller result = new Seller();
            result.SellerId = Convert.ToInt32(reader["seller_id"]);
            result.SellerName = Convert.ToString(reader["seller_name"]);
            result.SellerName = Convert.ToString(reader["seller_name"]);
            result.SellerType = Convert.ToString(reader["seller_type"]);
            result.Address1 = reader["address1"] is DBNull ? null : Convert.ToString(reader["address1"]);
            result.Address2 = reader["address2"] is DBNull ? null : Convert.ToString(reader["address2"]);
            result.City = reader["city"] is DBNull ? null : Convert.ToString(reader["city"]);
            result.State = reader["state"] is DBNull ? null : Convert.ToString(reader["state"]);
            result.Zip = reader["zip"] is DBNull ? null : Convert.ToString(reader["zip"]);
            result.Website = reader["website"] is DBNull ? null : Convert.ToString(reader["website"]);

            return result;
        }

        public List<Seller> GetSellers()
        {
            List<Seller> sellerList = new List<Seller>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetSellers, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Seller thisSeller = new Seller();
                            thisSeller = MapRowToSeller(reader);
                            sellerList.Add(thisSeller);

                        }
                    }
                }
            }
            return sellerList;
        }
        public Seller GetSellerById(int sellerId)
        {

            Seller sellerResult = new Seller();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetSellerById, conn))
                {
                    cmd.Parameters.AddWithValue("@seller_id", sellerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sellerResult = MapRowToSeller(reader);
                        }
                    }
                }
            }
            return sellerResult;
        }
        public List<int> GetSellerInventoryById(int sellerId)
        {
            List<int> inventoryList = new List<int>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetSellers, conn))
                {
                    cmd.Parameters.AddWithValue("@seller_id", sellerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            int thisInt = Convert.ToInt32(reader["plant_id"]);
                            inventoryList.Add(thisInt);

                        }
                    }
                }
            }
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
