namespace Capstone.DAO
{
    using System;
    using System.Collections.Generic;
    using Capstone.Models;

    
    public interface ITasksDao 
    {
      
        public List<Tasks> GetTasks();

        public Tasks GetTasksById(int taskId);

        public List<Tasks> GetMyTaskReminders(int userId);
        public bool DeleteTask(int taskId);

        public int UpdateTaskAck(TasksAck ack);

        public Tasks AddTask(Tasks taskToAdd);
        public Tasks UpdateTask(Tasks taskToUpdate);

        public List<Tasks> GetTasksByPlantId(int plantId);
    }
}
