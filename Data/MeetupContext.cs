using Data.Entities;
using Data.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MeetupContext : DbContext
    {
        public MeetupContext()
        {

        }

        public MeetupContext(DbContextOptions<MeetupContext> options)
            : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig())
                        .ApplyConfiguration(new OrganizerConfig())
                        .ApplyConfiguration(new RoleConfig())
                        .ApplyConfiguration(new SpeakerConfig())
                        .ApplyConfiguration(new UserConfig());
        }
    }
}
