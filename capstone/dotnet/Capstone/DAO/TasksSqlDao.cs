﻿using Capstone.Models;
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
        private readonly string SqlAddTask = @"INSERT INTO tasks (plant_id, task_description, task_category, frequency_days)
        VALUES (@plant_id, @task_description, @task_category, @frequency_days);";
        //        private readonly string SqlGetFutureEvents = @"SELECT [event_id],[user_id],[address1],[address2],[city],[state],[zip],[website],[name],[short_description]
        //      ,[long_description],[is_virtual],[start_time],[end_time] FROM [final_capstone].[dbo].[events]  WHERE start_time > GETDATE();";

        private readonly string SqlUpdateTask = @"UPDATE tasks SET task_description=@taskDescription, task_ategory=@taskCategory, frequency_days=@frequencyDays, " +
        "WHERE task_id = @taskId;";





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

        public int UpdateTaskAck(TasksAck ack)
        {
            string sqlUpdateTaskAck = @"UPDATE user_ack_task 
                                        SET last_ack = GETDATE()
                                        WHERE user_ack_task.user_id = @user_id AND user_ack_task.task_id = @task_id;";
            string sqlCreateTaskAck = @"INSERT INTO user_ack_task (user_id, task_id, last_ack) VALUES (@user_id, @task_id, GETDATE());";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlUpdateTaskAck, conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", ack.UserId);
                    cmd.Parameters.AddWithValue("@task_id", ack.TaskId);


                    int count = cmd.ExecuteNonQuery();
                    if (count == 0)
                    {
                        using (SqlCommand cmdInsert = new SqlCommand(sqlCreateTaskAck, conn))
                        {
                            //insert row if update not completed
                            cmd.Parameters.AddWithValue("@user_id", ack.UserId);
                            cmd.Parameters.AddWithValue("@task_id", ack.TaskId);
                            int countAdded = cmd.ExecuteNonQuery();
                            return countAdded;
                        }
                    }
                    else
                    {
                        return count;
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

        public Tasks AddTask(Tasks taskToAdd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlAddTask, conn))
                {

                    cmd.Parameters.AddWithValue("@plantId", taskToAdd.PlantId);
                    cmd.Parameters.AddWithValue("@task_description", taskToAdd.TaskDescription);
                    cmd.Parameters.AddWithValue("@task_category", taskToAdd.TaskCategory);
                    cmd.Parameters.AddWithValue("@frequency_days", taskToAdd.FrequencyDays);

                    taskToAdd.TaskId = (int)cmd.ExecuteNonQuery();
                }

            }

            return taskToAdd;
        }

        public Tasks UpdateTask(Tasks taskToUpdate)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(SqlUpdateTask, conn))
                {
                    cmd.Parameters.AddWithValue("@plantId", taskToUpdate.PlantId);
                    cmd.Parameters.AddWithValue("@task_description", taskToUpdate.TaskDescription);
                    cmd.Parameters.AddWithValue("@task_category", taskToUpdate.TaskCategory);
                    cmd.Parameters.AddWithValue("@frequency_days", taskToUpdate.FrequencyDays);
                    int count = cmd.ExecuteNonQuery();
                    if (count == 1)
                    {
                        return taskToUpdate;
                    }
                    else
                    {
                        return null;
                    }


                }
            }
        }






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
