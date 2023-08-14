using System;

namespace Capstone.Models
{
    public class Communication
    {
        public int CommunicationId { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PollOption1 { get; set; }
        public string PollOption2 { get; set; }
        public string PollOption3 { get; set; }
        public string PollOption4 { get; set; }

        public Communication() { }
        public Communication(int communicationId,
            int userId,
            string title,
            string type,
            DateTime startTime,
            DateTime endTime,
            string pollOption1,
            string pollOption2,
            string pollOption3,
            string pollOption4)
        {
            CommunicationId = communicationId;
            UserId = userId;
            Title = title;
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
            PollOption1 = pollOption1;
            PollOption2 = pollOption2;
            PollOption3 = pollOption3;
            PollOption4 = pollOption4;

        }
    }
}
