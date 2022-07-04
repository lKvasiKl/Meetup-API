namespace Meetup_API.Models.Responce
{
    public class EventResponce
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }

        public ICollection<OrganizerResponce> Organizers { get; set; }
        public ICollection<SpeakerResponce> Speakers { get; set; }
    }
}
