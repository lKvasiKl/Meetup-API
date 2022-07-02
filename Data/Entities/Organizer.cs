namespace Data.Entities
{
    public class Organizer : Entity<int>
    {
        public Organizer() => Events = new HashSet<Event>();

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
