using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessPostgres.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Games)
            .WithOne(a => a.User);

        builder.HasMany(c => c.Comments)
            .WithOne(m => m.User);
    }
}