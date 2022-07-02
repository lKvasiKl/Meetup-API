namespace Data.Entities
{
    public class Role : Entity<int>
    {
        public Role() => Users = new HashSet<User>();

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
