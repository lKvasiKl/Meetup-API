using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntitiesConfig
{
    internal sealed class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");

            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
            entity.Property(e => e.Email).IsRequired().HasMaxLength(128);
            entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(128);

            entity.HasOne(x => x.Role)
                  .WithMany(x => x.Users)
                  .HasForeignKey(x => x.RoleId);
        }
    }
}
