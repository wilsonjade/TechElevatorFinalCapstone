using Capstone.Models;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class RatingsSqlDao : IRatingDao
    {
        private readonly string SqlGetRatings = @"SELECT rating_id, user_id, seller_id, title, rating, review FROM ratings;";
        private readonly string SqlAddRatings = @"INSERT INTO ratings (user_id, seller_id, title, rating, review) VALUES (@user_id, @seller_id, @title, @rating, @review);";
        private readonly string SqlDeleteRatings = @"DELETE FROM ratings WHERE rating_id = @rating_id;";
        private readonly string connectionString;


        public RatingsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Ratings> GetRatings()
        {
            List<Ratings> ratingsList = new List<Ratings>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SqlGetRatings, conn))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Ratings rating = new Ratings();
                            rating = MapRowToRatings(reader);
                            ratingsList.Add(rating);

                        }
                    }

                }
            }

            return ratingsList;
        }

        

        public Ratings AddRatings(Ratings ratingToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SqlAddRatings, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", ratingToAdd.UserId);
                    cmd.Parameters.AddWithValue("@seller_id", ratingToAdd.SellerId);
                    cmd.Parameters.AddWithValue("@title", ratingToAdd.Title);
                    cmd.Parameters.AddWithValue("@rating", ratingToAdd.Rating);
                    cmd.Parameters.AddWithValue("@review", ratingToAdd.Review);

                    ratingToAdd.RatingId = (int)cmd.ExecuteNonQuery();
                }
            }

            return ratingToAdd;
        }

        public bool DeleteRating(int ratingId)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SqlDeleteRatings, conn))
                {
                    cmd.Parameters.AddWithValue("@rating_id", ratingId);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
        }


        private Ratings MapRowToRatings(SqlDataReader reader)
        {
            Ratings rating = new Ratings();
            rating.RatingId = Convert.ToInt32(reader["rating_id"]);
            rating.UserId = Convert.ToInt32(reader["user_id"]);
            rating.SellerId = Convert.ToInt32(reader["seller_id"]);
            rating.Title = Convert.ToString(reader["title"]);
            rating.Rating = Convert.ToInt32(reader["rating"]);
            rating.Review = Convert.ToString(reader["review"]);

            return rating;

        }
    }
}
