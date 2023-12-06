using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QualicoatManager.Domain.Entities;

namespace QualicoatManager.Infrastructure.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<BaseUser>
    {
        public void Configure(EntityTypeBuilder<BaseUser> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(128);
            builder.HasMany(u => u.UserRoles)
               .WithOne(ur => ur.User) 
               .HasForeignKey(ur => ur.UserId)
               .IsRequired();

        }
    }
}

            //builder.HasMany(u => u.UserRoles).WithMany(r => r.Users);
                //.UsingEntity<UserRole>(
                //j => j.HasOne<UserRole>().WithMany().HasForeignKey(ur => ur.Id),
                //j => j.HasOne<BaseUser>().WithMany().HasForeignKey(ur => ur.Id));
