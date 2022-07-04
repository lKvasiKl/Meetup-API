namespace Data.Entities
{
    public class Organizer : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
