using Capstone.Exceptions;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PlantSqlDao
    {
        private readonly string connectionString;
        private readonly string sqlGetPlants = @"SELECT plant_id, kingdom, family, genus, species, common_name, order, subfamily, description FROM plants;";

        public PlantSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Plant MapRowToPlant(SqlDataReader reader)
        {
            Plant plant = new Plant();
            plant.PlantId = Convert.ToInt32(reader["plant_id"]);
            plant.Kingdom = Convert.ToString(reader["kingdom"]);
            plant.Family = Convert.ToString(reader["family"]);
            plant.Genus = Convert.ToString(reader["genus"]);
            plant.Species = Convert.ToString(reader["species"]);
            plant.CommonName = Convert.ToString(reader["common_name"]);
            plant.Order = Convert.ToString(reader["order"]);
            plant.Subfamily = Convert.ToString(reader["subfamily"]);
            plant.Description = Convert.ToString(reader["description"]);

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
    }
}
