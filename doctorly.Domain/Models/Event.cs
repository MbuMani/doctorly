namespace doctorly.Persistence.Models
{
    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Attendee> Attendees { get; set; }

        public DateTime StartTime { get; set; }
       
        public DateTime EndTime { get; set; }
    }
}
