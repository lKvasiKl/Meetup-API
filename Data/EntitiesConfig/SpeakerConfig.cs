using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfig
{
    internal sealed class SpeakerConfig : IEntityTypeConfiguration<Speaker>
    {
        public void Configure(EntityTypeBuilder<Speaker> entity)
        {
            entity.ToTable("Speakers");

            entity.HasIndex(e => e.Name).IsUnique();

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
        }
    }
}
