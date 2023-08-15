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

        public Communication() { }
        public Communication(int communicationId, int userId, string title, string type, DateTime startTime, DateTime endTime)
        {
            CommunicationId = communicationId;
            UserId = userId;
            Title = title;
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
        }
    }

    public class PollOptions
    {
        public int OptionId { get; set; }
        public int PollId { get; set; }
        public string Text { get; set; }

        public PollOptions() { }
        public PollOptions(int optionId, int pollId, string text)
        {
            OptionId = optionId;
            PollId = pollId;
            Text = text;
        }
    }

    public class PollResponse
    {
        public int ResponseId { get; set; }
        public int UserId { get; set; }
        public int PollId { get; set; }
        public int OptionId { get; set; }
        public DateTime SubmissionDate { get; set; }

        public PollResponse() { }
        public PollResponse(int responseId, int userId, int pollId, int optionId, DateTime submissionDate)
        {
            ResponseId = responseId;
            UserId = userId;
            PollId = pollId;
            OptionId = optionId;
            SubmissionDate = submissionDate;
        }
    }
}
