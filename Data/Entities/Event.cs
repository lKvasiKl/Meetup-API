namespace Data.Entities
{
    public class Event : Entity<int>
    {
        public Event()
        {
            Organizers = new HashSet<Organizer>();
            Speakers = new HashSet<Speaker>();
        }

        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public string Schedule { get; set; }
        public DateTime DateTime { get; set; }
        public string Place { get; set; }

        public ICollection<Organizer> Organizers { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}
