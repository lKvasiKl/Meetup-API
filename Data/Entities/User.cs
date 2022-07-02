namespace Data.Entities
{
    public class User : Entity<Guid>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
