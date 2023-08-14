namespace Capstone.DAO
{
    using System;
    using System.Collections.Generic;
    using Capstone.Models;

    
    public interface ITasksDao 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Full List of Events</returns>
        public List<Tasks> GetTasks();

        public List<Tasks> GetMyTaskReminders(int userId);
        public bool DeleteTask(int taskId);
    }
}
