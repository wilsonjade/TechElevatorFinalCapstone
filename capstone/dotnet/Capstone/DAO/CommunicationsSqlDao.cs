﻿using Capstone.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CommunicationsSqlDao //: ICommunicationDao
    {
        private readonly string connectionString;

        private readonly string SqlGetAllCommunications = "SELECT communication_id, user_id, type, title, description, " +
            "start_time, end_time FROM communications;";

        private readonly string SqlGetCommunicationsByType = "SELECT communication_id, user_id, type, title, description, " +
            "start_time, end_time FROM communications " +
            "WHERE type = @type;";

        private readonly string SqlGetFutureCommunications = "SELECT communication_id, user_id, type, title, description, " +
            "start_time, end_time FROM communications " +
            "WHERE start_time >= @start_time;";

        private readonly string SqlGetCommunicationById = "SELECT communication_id, user_id, type, title, description, " +
            "start_time, end_time FROM communications " +
            "WHERE communication_id = @communication_id;";

        private readonly string SqlAddCommunication = "INSERT INTO events (user_id, title, type, description, " +
            "start_time, end_time) VALUES (@userId, @title, @type, @description, @start_time, @end_time);";

        private readonly string SqlUpdateCommunication = "UPDATE events " +
            "SET user_id=@user_id, title=@title, type=@type, description=@description, " +
            "start_time=@start_time, end_time=@end_time " +
            "WHERE communication_id = @communication_id;";

        private readonly string SqlDeleteCommunication = @"DELETE FROM communications WHERE communication_id = @communication_id;";



        public CommunicationsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
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
                    cmd.Parameters.AddWithValue("@communivation_id", id);
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
                    cmd.Parameters.AddWithValue("@userId", communicationToAdd.UserId);
                    cmd.Parameters.AddWithValue("@title", communicationToAdd.Title);
                    cmd.Parameters.AddWithValue("@type", communicationToAdd.Type);
                    cmd.Parameters.AddWithValue("@description", communicationToAdd.Description);
                    cmd.Parameters.AddWithValue("@start_time", communicationToAdd.StartTime);
                    cmd.Parameters.AddWithValue("@end_time", communicationToAdd.EndTime);

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
                    cmd.Parameters.AddWithValue("@user-id", communicationToUpdate.UserId);
                    cmd.Parameters.AddWithValue("@title", communicationToUpdate.Title);
                    cmd.Parameters.AddWithValue("@type", communicationToUpdate.Type);
                    cmd.Parameters.AddWithValue("@description", communicationToUpdate.Description);
                    cmd.Parameters.AddWithValue("@start_time", communicationToUpdate.StartTime);
                    cmd.Parameters.AddWithValue("@end_time", communicationToUpdate.EndTime);

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
            communication.Description = Convert.ToString(reader["description"]);
            communication.StartTime = Convert.ToDateTime(reader["start_time"]);
            communication.EndTime = Convert.ToDateTime(reader["end_time"]);

            return communication;
        }
    }
}