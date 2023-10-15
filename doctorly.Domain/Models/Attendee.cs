namespace doctorly.Persistence.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
       
        public bool isAttending { get; set; }
    }
}
