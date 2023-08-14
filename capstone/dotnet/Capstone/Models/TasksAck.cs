using System;

namespace Capstone.Models
{
    public class TasksAck
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public DateTime LastAck{ get; set; }

       
    }
}
