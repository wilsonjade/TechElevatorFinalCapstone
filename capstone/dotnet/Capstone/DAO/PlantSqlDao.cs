using Capstone.Exceptions;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PlantSqlDao : IPlantDao
    {
        private readonly string connectionString;
        private readonly string sqlGetPlants = @"SELECT plant_id, kingdom, family, genus, species, common_name, [order], subfamily, description, sun, water, fertilizer, img_url FROM plants;";

        private readonly string sqlGetPlantById = @"SELECT plant_id, kingdom, family, genus, species, common_name, [order], subfamily, description, sun, water, fertilizer, img_url FROM plants WHERE plant_id = @plantId;";

        private readonly string sqlGetPlantsByUserId = @"SELECT user_id, vg.plant_id, plants.common_name, plants.description, plants.family, plants.genus, plants.img_url, plants.kingdom, plants.plant_id, plants.species, plants.[order], plants.subfamily, plants.sun, plants.water, plants.fertilizer FROM virtual_garden AS vg INNER JOIN plants ON plants.plant_id = vg.plant_id WHERE user_id = @user_id";

        private readonly string sqlAddPlantToVG = @"INSERT INTO virtual_garden(plant_id, user_id) VALUES(@plant_id, @user_id)";

        private readonly string sqlDeletePlantFromGarden = @"DELETE FROM virtual_garden WHERE @plant_id = plant_id AND @user_id = user_id";
        public PlantSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public Plant GetPlantById(int plantId)
        {
            Plant plant = new Plant();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetPlantById, conn))
                {
                    cmd.Parameters.AddWithValue("@plantId", plantId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            plant = MapRowToPlant(reader);
                        }
                    }
                }
            }
            return plant;
        }

        public Plant MapRowToPlant(SqlDataReader reader)
        {
            Plant plant = new Plant();
            plant.PlantId = Convert.ToInt32(reader["plant_id"]);
            plant.Kingdom = reader["kingdom"] is DBNull ? null : Convert.ToString(reader["kingdom"]);
            plant.Family = reader["family"] is DBNull ? null : Convert.ToString(reader["family"]);
            plant.Genus = reader["genus"] is DBNull ? null : Convert.ToString(reader["genus"]);
            plant.Species = reader["species"] is DBNull ? null : Convert.ToString(reader["species"]);
            plant.CommonName = reader["common_name"] is DBNull ? null : Convert.ToString(reader["common_name"]);
            plant.Order = reader["order"] is DBNull ? null : Convert.ToString(reader["order"]);
            plant.Subfamily = reader["subfamily"] is DBNull ? null : Convert.ToString(reader["subfamily"]);
            plant.Description = reader["description"] is DBNull ? null : Convert.ToString(reader["description"]);
            plant.Sun = reader["sun"] is DBNull ? null : Convert.ToString(reader["sun"]);
            plant.Water = reader["water"] is DBNull ? null : Convert.ToString(reader["water"]);
            plant.Fertilizer = reader["fertilizer"] is DBNull ? null : Convert.ToString(reader["fertilizer"]);
            plant.ImgUrl = reader["img_url"] is DBNull ? null : Convert.ToString(reader["img_Url"]);

            return plant;

        }

        public List<Plant> GetPlants()
        {
            List<Plant> plants = new List<Plant>();

            //sql string stored as class var

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetPlants, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Plant plant = MapRowToPlant(reader);
                        plants.Add(plant);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DaoException("SQL exception occurred", ex);
            }

            return plants;
        }
        public List<Plant> GetPlantsByUserId(int userId)
        {
            Plant plant = new Plant();
            List<Plant> plants = new List<Plant>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetPlantsByUserId, conn))
                {
                    cmd.Parameters.AddWithValue("@user_Id", userId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plant = MapRowToPlant(reader);
                            plants.Add(plant);
                        }
                    }
                }
            }
            return plants;
        }
        public bool AddPlantToVG(int plantId, int userId)
        {
          

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
               
                using (SqlCommand cmd = new SqlCommand(sqlAddPlantToVG, conn))
                {
                    cmd.Parameters.AddWithValue("@plant_id", plantId);
                    cmd.Parameters.AddWithValue("@user_id", userId);


                    //SqlCommand testcmd = new SqlCommand();
                    try
                    {
                        plantId = (int)cmd.ExecuteNonQuery(); 

                    }
                    catch (SqlException)
                    {
                        return false;
                        
                    }
                    
                    return true;
                }

            }

            
        }

        public bool DeletePlantFromGarden(int plantId, int userId)
        {
            bool deleteSuccess = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //delete foreign keyed table records plant
               
                using (SqlCommand cmd = new SqlCommand(sqlDeletePlantFromGarden, conn))
                {

                    cmd.Parameters.AddWithValue("@plant_id", plantId);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        deleteSuccess = true;
                    }
                    else
                    {
                        deleteSuccess = false;
                    }

                }
                
            }
            return deleteSuccess;
        }

    }
}