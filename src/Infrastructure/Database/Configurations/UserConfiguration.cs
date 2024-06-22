using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.ComplexProperty(
            u => u.Email,
            b => b.Property(e => e.Value).HasColumnName("email"));

        builder.ComplexProperty(
            u => u.FirstName,
            b => b.Property(e => e.Value).HasColumnName("first_name"));

        builder.ComplexProperty(
            u => u.LastName,
            b => b.Property(e => e.Value).HasColumnName("last_name"));

        builder.HasIndex(user => user.IdentityId).IsUnique();
    }
}
