using System;

namespace MeetingScheduler.Entity
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public int CreatedBy { get; set; }
    }
}
