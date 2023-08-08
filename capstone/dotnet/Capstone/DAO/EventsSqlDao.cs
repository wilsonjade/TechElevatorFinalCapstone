﻿using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class EventsSqlDao : IEventsDao
    {
        private readonly string connectionString;
        private readonly string SqlGetEvents = @"SELECT [event_id],[user_id],[address1],[address2],[city],[state],[zip],[website],[name],[short_description]
      ,[long_description],[is_virtual],[start_time],[end_time] FROM [final_capstone].[dbo].[events];";

        private readonly string SqlGetEventsById = @"SELECT [event_id],[user_id],[address1],[address2],[city],[state],[zip],[website],[name],[short_description]
      ,[long_description],[is_virtual],[start_time],[end_time] FROM [final_capstone].[dbo].[events] WHERE event_id = @eventId;";

        private readonly string SqlUpdateEvents = @"UPDATE events SET address1=@address1, address2=@address2, city=@city," +
            "state=@state, zip=@zip, website=@website, name=@name, short_description=@short_description, long_description=@long_description, is_virtual=@is_virtual, start_time=@start_time, end_time=@end_time" +
            "WHERE events_id = @eventsId;";

        public EventsSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Events> GetEvents()
        {
            List<Events> eventsList = new List<Events>();

            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using(SqlCommand cmd = new SqlCommand(SqlGetEvents, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Events events = new Events();
                            events = MapRowToEvents(reader);
                            eventsList.Add(events);

                        }
                    }
                }
            }
            return eventsList;
        }

        public Events GetEventById(int id)
        {
            Events events = new Events();
            return events;
        }

       
        public List<Events> GetFutureEvents()
        {
            List<Events> events = new List<Events>();
            return events;
        }
       
        public Events AddEvent(Events eventToAdd)
        {
            Events events = new Events();
            return events;
        }
        
        public Events UpdateEvent(Events eventsToUpdate)
        {
           using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdateEvents, conn))
                {
                    cmd.Parameters.AddWithValue("@address1", eventsToUpdate.Address1);
                    cmd.Parameters.AddWithValue("@address2", eventsToUpdate.Address2);
                    cmd.Parameters.AddWithValue("@city", eventsToUpdate.City);
                    cmd.Parameters.AddWithValue("@state", eventsToUpdate.State);
                    cmd.Parameters.AddWithValue("@zip", eventsToUpdate.Zip);
                    cmd.Parameters.AddWithValue("@website", eventsToUpdate.Website);
                    cmd.Parameters.AddWithValue("@name", eventsToUpdate.Name);
                    cmd.Parameters.AddWithValue("@short_description", eventsToUpdate.ShortDescription);
                    cmd.Parameters.AddWithValue("@long_description", eventsToUpdate.LongDescription);
                    cmd.Parameters.AddWithValue("@is_virtual", eventsToUpdate.IsVirtual);
                    cmd.Parameters.AddWithValue("@start_time", eventsToUpdate.StartTime);
                    cmd.Parameters.AddWithValue("@end_time", eventsToUpdate.EndTime);

                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return eventsToUpdate;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
           

           
        }
        
        public bool DeleteEvent(int eventId)
        {

            Events events = new Events();
            return false;
        }

        public Events MapRowToEvents(SqlDataReader reader)
        {
            Events events = new Events();
            events.EventId = Convert.ToInt32(reader["event_id"]);
            events.UserId = Convert.ToInt32(reader["user_id"]);
            events.Address1 = Convert.ToString(reader["address1"]);
            events.Address2 = Convert.ToString(reader["address2"]);
            events.City = Convert.ToString(reader["city"]);
            events.State = Convert.ToString(reader["state"]);
            events.Zip = Convert.ToString(reader["zip"]);
            events.Website = Convert.ToString(reader["website"]);
            events.Name = Convert.ToString(reader["name"]);
            events.ShortDescription = Convert.ToString(reader["short_description"]);
            events.LongDescription = Convert.ToString(reader["long_description"]);
            events.IsVirtual = Convert.ToBoolean(reader["is_virtual"]);
            events.StartTime = Convert.ToDateTime(reader["start_time"]);
            events.EndTime = Convert.ToDateTime(reader["end_time"]);
           
            return events;
        }
    }
}
