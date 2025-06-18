using DataAccessPostgres.Configurations;
using DataAccessPostgres.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgres;

public class ProgramDbContext(DbContextOptions<ProgramDbContext> options)
    : DbContext(options)
{
    public DbSet<GameEntity> Games { get; set; }
    
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<TagEntity> Tags { get; set; }

    public DbSet<CommentEntity> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}