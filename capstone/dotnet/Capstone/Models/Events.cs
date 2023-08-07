using System;

namespace Capstone.Models
{
    public class Events
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public bool IsVirtual { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Events() { }
        public Events(int eventId, 
            int userId,
            string name, 
            string shortDescription, 
            string longDescription, 
            bool isVirtual, 
            string website,
            string address1, 
            string address2, 
            string city, 
            string state, 
            string zip, 
            DateTime startTime,
            DateTime endTime)
        {
            EventId = eventId;
            UserId = userId;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            IsVirtual = isVirtual;
            Website = website;
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Zip = zip;
            StartTime = startTime;
            EndTime = endTime;

        }
    }
}
