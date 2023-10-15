namespace doctorly.Core.Models
{
    public class ExternalEventContract
    {
        public string Title { get; set; }

        public List<ExternalAttendeeContract> Attendees { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
