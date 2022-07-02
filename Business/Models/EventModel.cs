namespace Business.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }

        public ICollection<OrganizerModel> Organizers { get; set; }
        public ICollection<SpeakerModel> Speakers { get; set; }
    }
}
