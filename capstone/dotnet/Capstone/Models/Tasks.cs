using System;

namespace Capstone.Models
{
    public class Tasks
    {
        public int TaskId { get; set; }
        public int PlantId { get; set; }
        public string? TaskDescription { get; set; }

        public string? TaskCategory { get; set; }
        public int? FrequencyDays { get; set; }
    }
}
