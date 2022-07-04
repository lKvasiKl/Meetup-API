namespace Data.Entities
{
    public class Speaker : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}
