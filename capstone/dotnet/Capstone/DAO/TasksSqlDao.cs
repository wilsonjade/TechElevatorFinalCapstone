using Capstone.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class TasksSqlDao : ITasksDao
    {
        private readonly string connectionString;
        private readonly string SqlGetTasks = @"SELECT [task_id],[plant_id],[task_description],[task_category],[frequency_days] FROM [final_capstone].[dbo].[tasks];";

        private readonly string SqlGetTasksById = @"SELECT [task_id],[plant_id],[task_description],[task_category],[frequency_days] FROM [final_capstone].[dbo].[tasks] WHERE task_id = @taskId;";
        private readonly string SqlDeleteTask = @"DELETE tasks WHERE task_id = @task_id;";
        private readonly string sqlGetMyTaskReminders = @"SELECT tasks.task_id, tasks.plant_id, tasks.task_category, tasks.task_description, tasks.frequency_days FROM tasks
                                                        JOIN virtual_garden ON virtual_garden.plant_id = tasks.plant_id
                                                        JOIN plants ON plants.plant_id = tasks.plant_id
                                                        JOIN user_ack_task ON user_ack_task.task_id = tasks.task_id
                                                        WHERE virtual_garden.user_id = @user_id AND user_ack_task.user_id = @user_id AND DAY(GETDATE() - user_ack_task.last_ack) > tasks.frequency_days  ;";
        //        private readonly string SqlGetFutureEvents = @"SELECT [event_id],[user_id],[address1],[address2],[city],[state],[zip],[website],[name],[short_description]
        //      ,[long_description],[is_virtual],[start_time],[end_time] FROM [final_capstone].[dbo].[events]  WHERE start_time > GETDATE();";

        //        private readonly string SqlUpdateEvents = @"UPDATE events SET address1=@address1, address2=@address2, city=@city, " +
        //            "state=@state, zip=@zip, website=@website, name=@name, short_description=@short_description, long_description=@long_description, " +
        //            "is_virtual=@is_virtual, start_time=@start_time, end_time=@end_time " +
        //            "WHERE event_id = @eventId;";

        //        private readonly string SqlDeleteEvent = @"DELETE FROM events WHERE event_id = @eventId;";

        //        private readonly string SqlAddEvents = @"INSERT INTO events (user_id, address1, address2, city, state, zip, website, name, short_description, long_description, is_virtual, start_time, end_time) 
        //VALUES (@userId, @address1, @address2, @city, @state, @zip, @website, @name, @short_description, @long_description, @is_virtual, @start_time, @end_time);";

        public TasksSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Tasks> GetTasks()
        {
            List<Tasks> taskList = new List<Tasks>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetTasks, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tasks tasks = new Tasks();
                            tasks = MapRowToTasks(reader);
                            taskList.Add(tasks);

                        }
                    }
                }
            }
            return taskList;
        }

        public List<Tasks> GetMyTaskReminders(int userId)
        {
            List<Tasks> taskList = new List<Tasks>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlGetMyTaskReminders, conn))
                {
                    cmd.Parameters.AddWithValue("user_id", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tasks tasks = new Tasks();
                            tasks = MapRowToTasks(reader);
                            taskList.Add(tasks);

                        }
                    }
                }
            }
            return taskList;
        }

        public Tasks GetTasksById(int id)
        {
            Tasks tasks = new Tasks();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlGetTasksById, conn))
                {
                    cmd.Parameters.AddWithValue("@taskId", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks = MapRowToTasks(reader);
                        }
                    }
                }
            }
            return tasks;
        }
        public bool DeleteTask(int taskId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlDeleteTask, conn))
                {
                    cmd.Parameters.AddWithValue("@task_id", taskId);

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

        //public List<Events> GetFutureEvents()
        //{
        //    List<Events> eventsList = new List<Events>();

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(SqlGetFutureEvents, conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Events events = MapRowToEvents(reader);
        //                    eventsList.Add(events);

        //                }
        //            }
        //        }
        //    }
        //    return eventsList;
        //}

        //public Events AddEvent(Events eventToAdd)
        //{
        //    using(SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(SqlAddEvents, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@userId", eventToAdd.UserId);
        //            cmd.Parameters.AddWithValue("@address1", eventToAdd.Address1);
        //            cmd.Parameters.AddWithValue("@address2", eventToAdd.Address2);
        //            cmd.Parameters.AddWithValue("@city", eventToAdd.City);
        //            cmd.Parameters.AddWithValue("@state", eventToAdd.State);
        //            cmd.Parameters.AddWithValue("@zip", eventToAdd.Zip);
        //            cmd.Parameters.AddWithValue("@website", eventToAdd.Website);
        //            cmd.Parameters.AddWithValue("@name", eventToAdd.Name);
        //            cmd.Parameters.AddWithValue("@short_description", eventToAdd.ShortDescription);
        //            cmd.Parameters.AddWithValue("@long_description", eventToAdd.LongDescription);
        //            cmd.Parameters.AddWithValue("@is_virtual", eventToAdd.IsVirtual);
        //            cmd.Parameters.AddWithValue("@start_time", eventToAdd.StartTime);
        //            cmd.Parameters.AddWithValue("@end_time", eventToAdd.EndTime);

        //            eventToAdd.EventId = (int)cmd.ExecuteNonQuery();
        //        }

        //    }

        //    return eventToAdd;
        //}

        //public Events UpdateEvent(Events eventsToUpdate)
        //{
        //   using(SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(SqlUpdateEvents, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@eventId", eventsToUpdate.EventId);
        //            cmd.Parameters.AddWithValue("@address1", eventsToUpdate.Address1);
        //            cmd.Parameters.AddWithValue("@address2", eventsToUpdate.Address2);
        //            cmd.Parameters.AddWithValue("@city", eventsToUpdate.City);
        //            cmd.Parameters.AddWithValue("@state", eventsToUpdate.State);
        //            cmd.Parameters.AddWithValue("@zip", eventsToUpdate.Zip);
        //            cmd.Parameters.AddWithValue("@website", eventsToUpdate.Website);
        //            cmd.Parameters.AddWithValue("@name", eventsToUpdate.Name);
        //            cmd.Parameters.AddWithValue("@short_description", eventsToUpdate.ShortDescription);
        //            cmd.Parameters.AddWithValue("@long_description", eventsToUpdate.LongDescription);
        //            cmd.Parameters.AddWithValue("@is_virtual", eventsToUpdate.IsVirtual);
        //            cmd.Parameters.AddWithValue("@start_time", eventsToUpdate.StartTime);
        //            cmd.Parameters.AddWithValue("@end_time", eventsToUpdate.EndTime);

        //            int count = cmd.ExecuteNonQuery();
        //            if (count == 1)
        //            {
        //                return eventsToUpdate;
        //            }
        //            else
        //            {
        //                return null;
        //            }


        //        }
        //    }                     
        //}


        //public Events CreateEvent(Events newEvent)
        //{

        //}



        public Tasks MapRowToTasks(SqlDataReader reader)
        {
            Tasks tasks = new Tasks();
            tasks.TaskId = Convert.ToInt32(reader["task_id"]);
            tasks.PlantId = Convert.ToInt32(reader["plant_id"]);
            tasks.TaskDescription = Convert.ToString(reader["task_description"]);
            tasks.TaskCategory = Convert.ToString(reader["task_category"]);
            tasks.FrequencyDays = Convert.ToInt32(reader["frequency_days"]);


            return tasks;
        }
    }
}
