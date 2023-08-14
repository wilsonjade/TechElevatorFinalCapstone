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

        public Events GetEventById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Full List of events in the future</returns>
        public List<Events> GetFutureEvents();
        /// <summary>
        /// Insert event record to the database
        /// </summary>
        /// <param name="eventToAdd">Event object to insert</param>
        /// <returns>Inserted Event object</returns>
        public Events AddEvent(Events eventToAdd);
        /// <summary>
        /// Update an existing event record
        /// </summary>
        /// <param name="eventToUpdate">Event object</param>
        /// <returns>The updated Event object from the database</returns>
        public Events UpdateEvent(Events eventToUpdate);
        /// <summary>
        /// Deletes an event record
        /// </summary>
        /// <param name="eventId">Integer id of the event</param>
        /// <returns>Boolean representing success or failure</returns>
        public bool DeleteEvent(int eventId);
    }
}
