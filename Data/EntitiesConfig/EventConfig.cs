using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfig
{
    internal sealed class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Events");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(128);
            entity.Property(e => e.Topic).IsRequired().HasMaxLength(128);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(512);
            entity.Property(e => e.Schedule).IsRequired().HasMaxLength(512);
            entity.Property(e => e.DateTime).IsRequired().HasColumnType("datetime");
            entity.Property(e => e.Place).IsRequired().HasMaxLength(128);

            entity.HasMany(x => x.Organizers)
                  .WithMany(x => x.Events)
                  .UsingEntity<Dictionary<string, object>>(
                "EventOrganizer",
                right => right.HasOne<Organizer>()
                              .WithMany()
                              .HasForeignKey("OrganizerId"),
                left => left.HasOne<Event>()
                            .WithMany()
                            .HasForeignKey("EventId"),
                join =>
                {
                    join.HasKey("EventId", "OrganizerId");
                    join.ToTable("EventOrganizer");
                });

            entity.HasMany(x => x.Speakers)
                  .WithMany(x => x.Events)
                  .UsingEntity<Dictionary<string, object>>(
                "EventSpeker",
                right => right.HasOne<Speaker>()
                              .WithMany()
                              .HasForeignKey("SpeakerId"),
                left => left.HasOne<Event>()
                            .WithMany()
                            .HasForeignKey("EventId"),
                join =>
                {
                    join.HasKey("EventId", "SpeakerId");
                    join.ToTable("EventSpeaker");
                });
        }
    }
}
