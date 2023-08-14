using System;

namespace Capstone.Models
{
    public class Communication
    {
        public int CommunicationId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Communication() { }
        public Communication(int communicationId,
            int userId,
            string title,
            string type,
            string description,
            DateTime startTime,
            DateTime endTime)
        {
            CommunicationId = communicationId;
            UserId = userId;
            Title = title;
            Type = type;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;

        }
    }
}
