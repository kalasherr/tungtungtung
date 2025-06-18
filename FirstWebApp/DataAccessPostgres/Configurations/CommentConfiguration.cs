using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessPostgres.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
{
    public void Configure(EntityTypeBuilder<CommentEntity> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.User)
            .WithMany(c => c.Comments)
            .HasForeignKey(m => m.User_Id);

        builder.HasOne(m => m.Game)
            .WithMany(a => a.Comments)
            .HasForeignKey(m => m.Game_Id);

    }
}