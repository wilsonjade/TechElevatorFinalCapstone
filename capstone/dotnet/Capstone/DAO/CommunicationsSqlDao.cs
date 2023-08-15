using Capstone.Models;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Capstone.Models.Communication;

namespace Capstone.DAO
{
    public class CommunicationsSqlDao : ICommunicationDao
    {
        private readonly string connectionString;

        private readonly string SqlGetAllCommunications = "SELECT communication_id, user_id, type, title, " +
            "start_time, end_time FROM communications;";

<<<<<<< HEAD
        private readonly string SqlGetCommunicationsByType = @"SELECT * FROM communications JOIN poll_response ON poll_response.poll_id = communication_id " +
            "WHERE type = 'poll' AND poll_id = @poll_id;";
=======
        private readonly string SqlGetCommunicationsByType = "SELECT communication_id, user_id, type, title, " +
            "start_time, end_time FROM communications " +
            "WHERE type = @type;";
>>>>>>> a84d9fb52ff6d55a17e45195ba22699bb352d0a0

        private readonly string SqlGetFutureCommunications = "SELECT communication_id, user_id, type, title, " +
            "start_time, end_time FROM communications " +
            "WHERE start_time > GETDATE();";

        private readonly string SqlGetCommunicationById = "SELECT communication_id, user_id, type, title, " +
            "start_time, end_time FROM communications " +
            "WHERE communication_id = @communication_id;";

        private readonly string SqlAddCommunication = "INSERT INTO communications (user_id, title, type, " +
            "start_time, end_time) VALUES (@user_id, " +
            "@title, @type, @description, @start_time, @end_time);";

        private readonly string SqlUpdateCommunication = "UPDATE communications " +
            "SET user_id=@user_id, title=@title, type=@type, start_time=@start_time, " +
            "end_time=@end_time" +
            "WHERE communication_id = @communication_id;";

        private readonly string SqlDeleteCommunication = "DELETE FROM communications WHERE communication_id = @communication_id;";



        public CommunicationsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        [HttpGet]
        public List<Communication> GetCommunications()
        {
            List<Communication> communicationsList = new List<Communication>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetAllCommunications, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Communication communication = new Communication();
                            communication = MapRowToCommunications(reader);
                            communicationsList.Add(communication);
                        }
                    }
                }
            }
            return communicationsList;
        }

        [HttpGet("{type}")]
        public List<Communication> GetCommunicationsByType(string type)
        {
            List<Communication> communicationsList = new List<Communication>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetCommunicationsByType, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Communication communication = new Communication();
                            communication = MapRowToCommunications(reader);
                            communicationsList.Add(communication);
                        }
                    }
                }
            }
            return communicationsList;
        }
        public List<Communication> GetFutureCommunications()
        {
            List<Communication> communicationsList = new List<Communication>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetFutureCommunications, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Communication communication = MapRowToCommunications(reader);
                            communicationsList.Add(communication);

                        }
                    }
                }
            }
            return communicationsList;
        }
        public Communication GetCommunicationById(int id)
        {
            Communication communication = new Communication();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetCommunicationById, conn))
                {
                    cmd.Parameters.AddWithValue("@communication_id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            communication = MapRowToCommunications(reader);
                        }
                    }
                }
            }
            return communication;
        }
        public Communication AddCommunication(Communication communicationToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SqlAddCommunication, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", communicationToAdd.UserId);
                    cmd.Parameters.AddWithValue("@title", communicationToAdd.Title);
                    cmd.Parameters.AddWithValue("@type", communicationToAdd.Type);
                    cmd.Parameters.AddWithValue("@start_time", communicationToAdd.StartTime);
                    cmd.Parameters.AddWithValue("@end_time", communicationToAdd.EndTime);
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
                   
>>>>>>> a909d2e4ecc1a6238f7d28229d3b4bc53ec0f6c8
>>>>>>> a84d9fb52ff6d55a17e45195ba22699bb352d0a0

                    communicationToAdd.CommunicationId = (int)cmd.ExecuteNonQuery();
                }
            }
            return communicationToAdd;
        }
        public Communication UpdateCommunication(Communication communicationToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdateCommunication, conn))
                {
                    cmd.Parameters.AddWithValue("@communication_id", communicationToUpdate.CommunicationId);
                    cmd.Parameters.AddWithValue("@user_id", communicationToUpdate.UserId);
                    cmd.Parameters.AddWithValue("@title", communicationToUpdate.Title);
                    cmd.Parameters.AddWithValue("@type", communicationToUpdate.Type);
                    cmd.Parameters.AddWithValue("@start_time", communicationToUpdate.StartTime);
                    cmd.Parameters.AddWithValue("@end_time", communicationToUpdate.EndTime);
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
                
>>>>>>> a909d2e4ecc1a6238f7d28229d3b4bc53ec0f6c8
>>>>>>> a84d9fb52ff6d55a17e45195ba22699bb352d0a0

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return communicationToUpdate;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
        }
        public bool DeleteCommunication(int communicationId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlDeleteCommunication, conn))
                {
                    cmd.Parameters.AddWithValue("@communication_id", communicationId);

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
        private Communication MapRowToCommunications(SqlDataReader reader)
        {
            Communication communication = new Communication();
            communication.CommunicationId = Convert.ToInt32(reader["communication_id"]);
            communication.UserId = Convert.ToInt32(reader["user_id"]);
            communication.Title = Convert.ToString(reader["title"]);
            communication.Type = Convert.ToString(reader["type"]);
            communication.StartTime = Convert.ToDateTime(reader["start_time"]);
            communication.EndTime = Convert.ToDateTime(reader["end_time"]);
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
         
>>>>>>> a84d9fb52ff6d55a17e45195ba22699bb352d0a0

>>>>>>> a909d2e4ecc1a6238f7d28229d3b4bc53ec0f6c8
            return communication;
        }

        private PollOptions MapToPollOptions(SqlDataReader reader)
        {
            PollOptions pollOption = new PollOptions();
            pollOption.OptionId = Convert.ToInt32(reader["option_id"]);
            pollOption.PollId = Convert.ToInt32(reader["poll_id"]);
            pollOption.Text = Convert.ToString(reader["text"]);
            return pollOption;


        }
        private PollResponse MapToPollResponse(SqlDataReader reader)
        {
            PollResponse pollResponse = new PollResponse();
            pollResponse.ResponseId = Convert.ToInt32(reader["poll_id"]);
            pollResponse.UserId = Convert.ToInt32(reader["user_id"]);
            pollResponse.PollId = Convert.ToInt32(reader["poll_id"]);
            pollResponse.OptionId = Convert.ToInt32(reader["option_id"]);
            pollResponse.SubmissionDate = Convert.ToDateTime(reader["submission_date"]);
            return pollResponse;
        }


    }
}
