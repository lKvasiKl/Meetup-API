namespace Data.Entities
{
    public class Speaker : Entity<int>
    {
        public Speaker() => Events = new HashSet<Event>();

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
