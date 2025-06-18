using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessPostgres.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.User)
            .WithMany(c => c.Games)
            .HasForeignKey(a => a.User_Id);


        builder.HasMany(a => a.Comments)
            .WithOne(m => m.Game)
            .HasForeignKey(m => m.Game_Id);

        builder.HasMany(a => a.Tags)
            .WithMany(t => t.Games);
    }
}






